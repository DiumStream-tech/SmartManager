using System.Collections.Generic;

namespace Enhancer.Manager.Langue
{
    public static class ru
    {
        public static Dictionary<string, string> Translations = new()
        {
            { "ModLoaded", "Мод загружен:" },
            { "CartCleanerBtn", "Очистить корзину" },
            { "CartCleanerInitError", "Ошибка инициализации CartCleaner" },
            { "CartCleanerInitialized", "CartCleaner инициализирован." },
            { "MainSceneLoading", "Загрузка основной сцены..." },
            { "InfiniteOrdersInitialized", "InfiniteOrders инициализирован." },
            { "InfiniteOrdersInitError", "Ошибка инициализации InfiniteOrders" },
            { "BuyingPanelNotFound", "Панель для покупки не найдена!" },
            { "AutomaticPayment_Ready", "Готовы платить по счетам!" },
            { "AutomaticPayment_PayingBills", "Оплата счетов..." },
            { "AutomaticPayment_Error", "Невозможно получить доступ к Менеджеру расходов!" },
            { "AutomaticPayment_BillsPaid", "Счета оплачиваются автоматически!" },
            { "AmbientLight_Ready", "AmbientLightManager готов включить свет в" },
            { "AmbientLight_DayCycleManagerNotFound", "DayCycleManager не найден!" },
            { "AmbientLight_LightsOn", "Освещение включено!" },
            { "AmbientLight_InvalidTime", "Неверное время включения света. Сбрасываю на 18:00." },
            { "AmbientLightAdded", "AmbientLightManager добавлен в сцену." },
            { "AmbientLightInitError", "Ошибка инициализации AmbientLightManager" },
            { "TimeSwitchDescription", "Время включения света (формат ЧЧ:мм)" },
            { "LanguageDescription", "Язык, используемый для переводов (например, en, fr, de, it, ru)" }
        };
    }
}
