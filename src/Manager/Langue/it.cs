using System.Collections.Generic;

namespace Enhancer.Manager.Langue
{
    public static class it
    {
        public static Dictionary<string, string> Translations = new()
        {
            { "ModLoaded", "Mod caricata:" },
            { "CartCleanerBtn", "Svuota il carrello" },
            { "CartCleanerInitError", "Errore durante l'inizializzazione di CartCleaner" },
            { "CartCleanerInitialized", "CartCleaner inizializzato." },
            { "MainSceneLoading", "Caricamento della scena principale..." },
            { "InfiniteOrdersInitialized", "InfiniteOrders inizializzato." },
            { "InfiniteOrdersInitError", "Errore durante l'inizializzazione di InfiniteOrders" },
            { "BuyingPanelNotFound", "Pannello 'Buying Panel' non trovato!" },
            { "AutomaticPayment_Ready", "Pronto per pagare le fatture!" },
            { "AutomaticPayment_PayingBills", "Pagamento delle fatture in corso..." },
            { "AutomaticPayment_Error", "Impossibile accedere a Expenses Manager!" },
            { "AutomaticPayment_BillsPaid", "Fatture pagate automaticamente!" },
            { "AmbientLight_Ready", "AmbientLightManager pronto per accendere le luci alle" },
            { "AmbientLight_DayCycleManagerNotFound", "DayCycleManager non trovato!" },
            { "AmbientLight_LightsOn", "Luci ambientali accese!" },
            { "AmbientLight_InvalidTime", "Orario non valido per accendere le luci. Reimpostazione alle 18:00." },
            { "AmbientLightAdded", "AmbientLightManager aggiunto alla scena." },
            { "AmbientLightInitError", "Errore durante l'inizializzazione di AmbientLightManager" },
            { "TimeSwitchDescription", "Orario di attivazione delle luci (formato HH:mm)" },
            { "LanguageDescription", "Lingua utilizzata per le traduzioni (es: en, fr, de, it, ru)" }
        };
    }
}
