using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SmartManager.Manager;
using HarmonyLib;

namespace SmartManager.Cart
{
    public static class CartUtilities
    {
        public static GameObject CreateClearCartButton(GameObject buyingPanel, GameObject purchaseButton)
        {
            Debug.Log("[SmartManager] Création du bouton de nettoyage du panier...");
            GameObject clearCartBtn = new GameObject("Clear Cart Button");

            RectTransform rectTransform = clearCartBtn.AddComponent<RectTransform>();
            SetupButtonTransform(rectTransform, buyingPanel.transform, purchaseButton.GetComponent<RectTransform>());

            Image image = clearCartBtn.AddComponent<Image>();
            image.sprite = purchaseButton.GetComponent<Image>().sprite;
            image.color = new Color32(255, 112, 112, 255);

            Button button = clearCartBtn.AddComponent<Button>();
            button.onClick.AddListener(CartCleaner.CleanCart);

            CreateButtonText(clearCartBtn, purchaseButton);

            Debug.Log("[SmartManager] Bouton de nettoyage du panier créé avec succès !");
            return clearCartBtn;
        }

        private static void SetupButtonTransform(RectTransform rectTransform, Transform parent, RectTransform referenceRect)
        {
            rectTransform.SetParent(parent, false);
            rectTransform.sizeDelta = referenceRect.sizeDelta;
            rectTransform.anchorMin = referenceRect.anchorMin;
            rectTransform.anchorMax = referenceRect.anchorMax;
            rectTransform.anchoredPosition = new Vector2(referenceRect.anchoredPosition.x, referenceRect.anchoredPosition.y - referenceRect.sizeDelta.y - 5);
        }

        private static void CreateButtonText(GameObject button, GameObject referenceButton)
        {
            GameObject textObject = new GameObject("Text (TMP)");
            textObject.transform.SetParent(button.transform, false);
            TextMeshProUGUI textMeshProUGUI = textObject.AddComponent<TextMeshProUGUI>();
            textMeshProUGUI.text = TraductionsManager.GetTraduction("CartCleanerBtn");
            textMeshProUGUI.fontSize = referenceButton.GetComponentInChildren<TextMeshProUGUI>().fontSize;
            textMeshProUGUI.color = Color.white;
            textMeshProUGUI.alignment = TextAlignmentOptions.Center;

            RectTransform textRectTransform = textMeshProUGUI.GetComponent<RectTransform>();
            textRectTransform.anchorMin = Vector2.zero;
            textRectTransform.anchorMax = Vector2.one;
            textRectTransform.sizeDelta = Vector2.zero;
        }

        public static void CleanCartInternal()
        {
            Debug.Log("[SmartManager] Nettoyage du panier...");
            MarketShoppingCart cartInstance = Object.FindFirstObjectByType<MarketShoppingCart>();
            if (cartInstance != null)
            {
                var cleanCartMethod = AccessTools.Method(typeof(MarketShoppingCart), "CleanCart");
                if (cleanCartMethod != null)
                {
                    cleanCartMethod.Invoke(cartInstance, null);
                    Debug.Log("[SmartManager] Panier nettoyé avec succès !");
                }
                else
                {
                    Debug.LogError("[SmartManager] Méthode CleanCart non trouvée.");
                }
            }
        }
    }
}
