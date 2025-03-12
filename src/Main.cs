using System;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;
using SmartManager.Manager;
using SmartManager.AutomaticPayment;
using SmartManager.AmbientLight;
using SmartManager.Cart;
using SmartManager.Orders;

namespace SmartManager
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Main : BaseUnityPlugin
    {
        private Harmony harmony;
        public static ConfigEntry<string> TimeToSwitch;
        public static BepInEx.Logging.ManualLogSource Log;

        private GameObject _ambientLightManagerObject;

        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            Log = Logger;

            // Initialisation de TraductionsManager et création des fichiers
            TraductionsManager.Initialize();

            // Chargement de la langue configurée
            string language = Config.Bind(
                "Localization", 
                "Language", 
                "en", 
                "Language used for translations (e.g. en, fr, de, it, ru)"
            ).Value;
            
            TraductionsManager.LoadTranslations(language);

            Log.LogInfo($"[SmartManager] {TraductionsManager.GetTraduction("ModLoaded")} {PluginInfo.PLUGIN_NAME} v{PluginInfo.PLUGIN_VERSION}");
            
            // Configuration de l'heure d'activation des lumières
            TimeToSwitch = Config.Bind(
                "AmbientLight", 
                TraductionsManager.GetTraduction("TimeSwitchDescription"), 
                "18:00",
                TraductionsManager.GetTraduction("TimeSwitchDescription")
            );

            // Application des patches Harmony
            harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            // Initialisation des fonctionnalités
            AutomaticPaymentManager.Initialize();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            harmony?.UnpatchSelf();

            if (_ambientLightManagerObject != null)
            {
                Destroy(_ambientLightManagerObject);
                _ambientLightManagerObject = null;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Main Scene")
            {
                Log.LogInfo("[SmartManager] " + TraductionsManager.GetTraduction("MainSceneLoading"));
                
                InitializeNoCartLimits();
                InitializeCartCleaner();
                InitializeAmbientLightManager();
                AutomaticPaymentManager.OnSceneLoaded(scene, mode);
            }
            else
            {
                if (_ambientLightManagerObject != null)
                {
                    Destroy(_ambientLightManagerObject);
                    _ambientLightManagerObject = null;
                }
            }
        }

        private void InitializeNoCartLimits()
        {
            try
            {
                InfiniteOrders.OnSceneLoaded();
                Log.LogInfo("[SmartManager] " + TraductionsManager.GetTraduction("InfiniteOrdersInitialized"));
            }
            catch (Exception e)
            {
                Log.LogError($"[SmartManager] {TraductionsManager.GetTraduction("InfiniteOrdersInitError")}: {e.Message}");
            }
        }

        private void InitializeCartCleaner()
        {
            try
            {
                GameObject buyingPanel = GameObject.Find("---GAME---/Computer/Screen/Market App/Cart/Cart Window/Window BG/Buying Panel");
                if (buyingPanel != null)
                {
                    CartCleaner.Setup(buyingPanel);
                    Log.LogInfo("[SmartManager] " + TraductionsManager.GetTraduction("CartCleanerInitialized"));
                }
                else
                {
                    Log.LogError("[SmartManager] " + TraductionsManager.GetTraduction("BuyingPanelNotFound"));
                }
            }
            catch (Exception e)
            {
                Log.LogError($"[SmartManager] {TraductionsManager.GetTraduction("CartCleanerInitError")}: {e.Message}");
            }
        }

        private void InitializeAmbientLightManager()
        {
            try
            {
                _ambientLightManagerObject = new GameObject("AmbientLightManager");
                _ambientLightManagerObject.AddComponent<AmbientLightManager>();
                Log.LogInfo("[SmartManager] " + TraductionsManager.GetTraduction("AmbientLightAdded"));
            }
            catch (Exception e)
            {
                Log.LogError($"[SmartManager] {TraductionsManager.GetTraduction("AmbientLightInitError")}: {e.Message}");
            }
        }
    }
}
