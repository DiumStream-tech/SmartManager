using HarmonyLib;
using UnityEngine;
using SmartManager.Orders;

namespace SmartManager.Orders
{
    public static class InfiniteOrders
    {
        public static void OnSceneLoaded()
        {
            Debug.Log("[SmartManager] Initialisation des fonctionnalités...");
            SupplyUtilities.CorrectObjectPositions();
        }

        public static bool CartMaxed()
        {
            return false;
        }

        [HarmonyPatch(typeof(MarketShoppingCart), "TryAddProduct")]
        private class MarketShoppingCart_TryAddProduct_Patch
        {
            private static System.Reflection.MethodInfo AddProductMethod = typeof(MarketShoppingCart).GetMethod("AddProduct", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            private static bool Prefix(MarketShoppingCart __instance, ItemQuantity salesItem, SalesType salesType)
            {
                AddProductMethod.Invoke(__instance, new object[] { salesItem, salesType });
                return false;
            }
        }

        [HarmonyPatch(typeof(MarketShoppingCart), "CartMaxed")]
        public static class Patch_CartMaxed
        {
            [HarmonyPrefix]
            private static bool Prefix(ref bool __result)
            {
                __result = CartMaxed();
                return false;
            }
        }
    }
}
