using System.Collections.Generic;

namespace Enhancer.Manager.Langue
{
    public static class en
    {
        public static Dictionary<string, string> Translations = new()
        {
            { "ModLoaded", "Mod loaded:" },
            { "CartCleanerBtn", "Clear Cart" },
            { "CartCleanerInitError", "Error initializing CartCleaner" },
            { "CartCleanerInitialized", "CartCleaner initialized." },
            { "MainSceneLoading", "Loading main scene..." },
            { "InfiniteOrdersInitialized", "InfiniteOrders initialized." },
            { "InfiniteOrdersInitError", "Error initializing InfiniteOrders" },
            { "BuyingPanelNotFound", "Buying Panel not found!" },
            { "AutomaticPayment_Ready", "Ready to pay bills!" },
            { "AutomaticPayment_PayingBills", "Paying bills..." },
            { "AutomaticPayment_Error", "Unable to access Expenses Manager!" },
            { "AutomaticPayment_BillsPaid", "Bills paid automatically!" },
            { "AmbientLight_Ready", "AmbientLightManager ready to turn on lights at" },
            { "AmbientLight_DayCycleManagerNotFound", "DayCycleManager not found!" },
            { "AmbientLight_LightsOn", "Ambient lights turned on!" },
            { "AmbientLight_InvalidTime", "Invalid time to turn on lights. Resetting to 18:00." },
            { "AmbientLightAdded", "AmbientLightManager added to the scene." },
            { "AmbientLightInitError", "Error initializing AmbientLightManager" },
            { "TimeSwitchDescription", "Time to activate lights (format HH:mm)" },
            { "LanguageDescription", "Language used for translations (e.g. en, fr, de, it, ru)" }
        };
    }
}
