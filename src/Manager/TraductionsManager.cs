using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using Newtonsoft.Json;
using UnityEngine;

namespace SmartManager.Manager
{
    public static class TraductionsManager
    {
        private static readonly string LangueFolder = Path.Combine(Paths.ConfigPath, "SmartManager", "Langue");
        private static Dictionary<string, string> currentTranslations;
        private static Dictionary<string, string> defaultTranslations;

        public static void Initialize()
        {
            EnsureDirectoryExists(LangueFolder);
            GenerateJsonFromCsClasses();
            LoadDefaultLanguage();
        }

        private static void GenerateJsonFromCsClasses()
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            foreach (var type in assembly.GetTypes()
                .Where(t => t.Namespace == "Enhancer.Manager.Langue" && t.IsClass && t.IsAbstract && t.IsSealed))
            {
                try
                {
                    var langCode = type.Name.ToLower();
                    var translations = type.GetField("Translations", BindingFlags.Public | BindingFlags.Static)?
                        .GetValue(null) as Dictionary<string, string>;

                    if (translations != null)
                    {
                        var jsonPath = Path.Combine(LangueFolder, $"{langCode}.json");
                        File.WriteAllText(jsonPath, JsonConvert.SerializeObject(translations, Formatting.Indented));
                        Debug.Log($"[SmartManager] Fichier JSON généré : {langCode}.json");
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[SmartManager] Erreur de génération JSON : {ex.Message}");
                }
            }
        }

        private static void LoadDefaultLanguage()
        {
            var enPath = Path.Combine(LangueFolder, "en.json");
            if (File.Exists(enPath))
            {
                defaultTranslations = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(enPath));
            }
            else
            {
                Debug.LogError("[SmartManager] Fichier de langue par défaut (en.json) introuvable !");
                defaultTranslations = new Dictionary<string, string>();
            }
        }

        public static void LoadTranslations(string language)
        {
            var langCode = language.ToLower();
            var jsonPath = Path.Combine(LangueFolder, $"{langCode}.json");

            if (File.Exists(jsonPath))
            {
                try
                {
                    currentTranslations = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(jsonPath));
                    Debug.Log($"[SmartManager] Langue chargée : {langCode}");
                }
                catch (Exception ex)
                {
                    Debug.LogError($"[SmartManager] Erreur de chargement {langCode}.json : {ex.Message}");
                    currentTranslations = defaultTranslations;
                }
            }
            else
            {
                Debug.LogWarning($"[SmartManager] Fichier {langCode}.json introuvable, utilisation de l'anglais");
                currentTranslations = defaultTranslations;
            }
        }

        public static string GetTraduction(string key)
        {
            if (currentTranslations.TryGetValue(key, out var value))
                return value;

            if (defaultTranslations.TryGetValue(key, out value))
                return value;

            Debug.LogWarning($"[SmartManager] Clé de traduction manquante : {key}");
            return $"!{key}!";
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }
    }
}
