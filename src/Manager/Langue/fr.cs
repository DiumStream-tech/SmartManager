using System.Collections.Generic;

namespace Enhancer.Manager.Langue
{
    public static class fr
    {
        public static Dictionary<string, string> Translations = new()
        {
            { "ModLoaded", "Mod chargé :" },
            { "CartCleanerBtn", "Vider le panier" },
            { "CartCleanerInitError", "Erreur lors de l'initialisation de CartCleaner" },
            { "CartCleanerInitialized", "CartCleaner initialisé." },
            { "MainSceneLoading", "Chargement de la scène principale..." },
            { "InfiniteOrdersInitialized", "InfiniteOrders initialisé." },
            { "InfiniteOrdersInitError", "Erreur lors de l'initialisation de InfiniteOrders" },
            { "BuyingPanelNotFound", "Panneau 'Buying Panel' introuvable !" },
            { "AutomaticPayment_Ready", "Prêt à payer les factures !" },
            { "AutomaticPayment_PayingBills", "Paiement des factures en cours..." },
            { "AutomaticPayment_Error", "Impossible d'accéder à Expenses Manager !" },
            { "AutomaticPayment_BillsPaid", "Factures payées automatiquement !" },
            { "AmbientLight_Ready", "AmbientLightManager prêt à allumer les lumières à" },
            { "AmbientLight_DayCycleManagerNotFound", "DayCycleManager introuvable !" },
            { "AmbientLight_LightsOn", "Lumières ambiantes allumées !" },
            { "AmbientLight_InvalidTime", "Heure invalide pour allumer les lumières. Réinitialisation à 18:00." },
            { "AmbientLightAdded", "AmbientLightManager ajouté à la scène." },
            { "AmbientLightInitError", "Erreur lors de l'initialisation d'AmbientLightManager" },
            { "TimeSwitchDescription", "Heure d'activation des lumières (format HH:mm)" },
            { "LanguageDescription", "Langue utilisée pour les traductions (ex: en, fr, de, it, ru)" }
        };
    }
}
