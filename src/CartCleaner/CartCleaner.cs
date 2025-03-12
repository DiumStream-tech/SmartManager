using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SmartManager.Manager;

namespace SmartManager.Cart
{
    public class CartCleaner
    {
        private static GameObject clearCartBtn;

        public static void Setup(GameObject buyingPanel)
        {
            Debug.Log("[SmartManager] Mise à jour de l'interface du panier...");
            if (buyingPanel == null)
            {
                Debug.LogError("[SmartManager] Panneau 'Buying Panel' introuvable !");
                return;
            }

            GameObject purchaseButton = buyingPanel.transform.Find("Purchase Button")?.gameObject;
            if (purchaseButton == null)
            {
                Debug.LogError("[SmartManager] Bouton 'Acheter' introuvable !");
                return;
            }

            if (clearCartBtn != null)
            {
                Object.Destroy(clearCartBtn);
            }

            clearCartBtn = CartUtilities.CreateClearCartButton(buyingPanel, purchaseButton);
        }

        public static void CleanCart()
        {
            CartUtilities.CleanCartInternal();
        }
    }
}
