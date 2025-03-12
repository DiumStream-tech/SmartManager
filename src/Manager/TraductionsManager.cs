using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BepInEx;
using Newtonsoft.Json;
using UnityEngine;

namespace SmartManager.Manager
{
    public static class TraductionsManager
    {
        private static readonly string SmartModsFolder = Path.Combine(Paths.ConfigPath, "SmartMods");
        private static readonly string LangueFolder = Path.Combine(SmartModsFolder, "SmartManager", "Langue");
        private static Dictionary<string, string> currentTranslations;

        public static void Initialize()
        {
            EnsureDirectoryExists(SmartModsFolder);
            EnsureDirectoryExists(LangueFolder);
            VerifyAndUpdateLanguageFiles();
        }

        public static void LoadTranslations(string language)
        {
            string filePath = Path.Combine(LangueFolder, $"{language}.json");
            
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                currentTranslations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                Debug.Log($"[SmartManager] Traductions chargées : {language}");
            }
            else
            {
                Debug.LogWarning($"[SmartManager] Fichier de langue introuvable : {language}.json. Utilisation de l'anglais par défaut.");
                currentTranslations = LoadEmbeddedTranslations("en");
            }
        }

        private static void VerifyAndUpdateLanguageFiles()
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            foreach (var type in assembly.GetTypes())
            {
                if (type.Namespace == "SmartManager.Manager.Langue" && type.IsClass)
                {
                    var embeddedTranslations = type.GetField("Translations")?.GetValue(null) as Dictionary<string, string>;
                    if (embeddedTranslations != null)
                    {
                        string languageCode = type.Name.ToLower();
                        string filePath = Path.Combine(LangueFolder, $"{languageCode}.json");
                        
                        if (File.Exists(filePath))
                        {
                            string json = File.ReadAllText(filePath);
                            var existingTranslations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                            if (IsTranslationDifferent(embeddedTranslations, existingTranslations))
                            {
                                UpdateLanguageFile(filePath, embeddedTranslations);
                                Debug.Log($"[SmartManager] Fichier de langue mis à jour : {languageCode}.json");
                            }
                        }
                        else
                        {
                            UpdateLanguageFile(filePath, embeddedTranslations);
                            Debug.Log($"[SmartManager] Nouveau fichier de langue créé : {languageCode}.json");
                        }
                    }
                }
            }
        }

        private static bool IsTranslationDifferent(Dictionary<string, string> embedded, Dictionary<string, string> existing)
        {
            if (embedded.Count != existing.Count) return true;

            foreach (var kvp in embedded)
            {
                if (!existing.TryGetValue(kvp.Key, out string value) || value != kvp.Value)
                {
                    return true;
                }
            }

            return false;
        }

        private static void UpdateLanguageFile(string filePath, Dictionary<string, string> translations)
        {
            string json = JsonConvert.SerializeObject(translations, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private static Dictionary<string, string> LoadEmbeddedTranslations(string lang)
        {
            var type = Type.GetType($"SmartManager.Manager.Langue.{lang}");
            return type?.GetField("Translations")?.GetValue(null) as Dictionary<string, string> ?? new Dictionary<string, string>();
        }

        private static void EnsureDirectoryExists(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        public static string GetTraduction(string key)
        {
            if (currentTranslations != null && currentTranslations.TryGetValue(key, out string value))
            {
                return value;
            }
            
            Debug.LogWarning($"[SmartManager] Clé de traduction manquante : {key}");
            return key;
        }
    }
}
