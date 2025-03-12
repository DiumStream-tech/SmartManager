using System.Collections.Generic;

namespace Enhancer.Manager.Langue
{
    public static class de
    {
        public static Dictionary<string, string> Translations = new()
        {
            { "ModLoaded", "Mod geladen:" },
            { "CartCleanerBtn", "Warenkorb leeren" },
            { "CartCleanerInitError", "Fehler bei der Initialisierung von CartCleaner" },
            { "CartCleanerInitialized", "CartCleaner initialisiert." },
            { "MainSceneLoading", "Hauptszene wird geladen..." },
            { "InfiniteOrdersInitialized", "InfiniteOrders initialisiert." },
            { "InfiniteOrdersInitError", "Fehler bei der Initialisierung von InfiniteOrders" },
            { "BuyingPanelNotFound", "'Buying Panel' nicht gefunden!" },
            { "AutomaticPayment_Ready", "Bereit, Rechnungen zu bezahlen!" },
            { "AutomaticPayment_PayingBills", "Rechnungen werden bezahlt..." },
            { "AutomaticPayment_Error", "Zugriff auf Expenses Manager nicht möglich!" },
            { "AutomaticPayment_BillsPaid", "Rechnungen automatisch bezahlt!" },
            { "AmbientLight_Ready", "AmbientLightManager bereit zum Einschalten der Lichter bei" },
            { "AmbientLight_DayCycleManagerNotFound", "DayCycleManager nicht gefunden!" },
            { "AmbientLight_LightsOn", "Ambientelicht eingeschaltet!" },
            { "AmbientLight_InvalidTime", "Ungültige Zeit zum Einschalten des Lichts. Zurücksetzen auf 18:00." },
            { "AmbientLightAdded", "AmbientLightManager zur Szene hinzugefügt." },
            { "AmbientLightInitError", "Fehler beim Initialisieren von AmbientLightManager" },
            { "TimeSwitchDescription", "Zeit bis zur Aktivierung der Lichter (Format HH:mm)" },
            { "LanguageDescription", "Für Übersetzungen verwendete Sprache (z. B. en, fr, de, it, ru)" }
        };
    }
}
