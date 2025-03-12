using UnityEngine;
using UnityEngine.SceneManagement;
using SmartManager.Manager;
using MyBox;

namespace SmartManager.AutomaticPayment
{
    public static class AutomaticPaymentManager
    {
        public static void Initialize()
        {
            Main.Log.LogInfo("[SmartManager] Initialisé !");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "Main Scene")
            {
                Main.Log.LogInfo("[SmartManager] Chargement de la scène principale...");
                Main.Instance.StartCoroutine(PaymentUtilities.PostLoad());
            }
        }
    }
}
