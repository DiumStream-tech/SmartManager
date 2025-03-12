using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MyBox;
using SmartManager.Manager;

namespace SmartManager.AutomaticPayment
{
    public static class PaymentUtilities
    {
        public static IEnumerator PostLoad()
        {
            yield return new WaitUntil(() => Singleton<DayCycleManager>.Instance != null);
            DayCycleManager instance = Singleton<DayCycleManager>.Instance;
            instance.OnStartedNewDay += ProcessPayments;
            Main.Log.LogInfo("[SmartManager] " + TraductionsManager.GetTraduction("AutomaticPayment_Ready"));
        }

        private static void ProcessPayments()
        {
            Main.Log.LogInfo("[SmartManager] " + TraductionsManager.GetTraduction("AutomaticPayment_PayingBills"));
            ExpensesManager expensesManager = Singleton<ExpensesManager>.Instance;

            if (expensesManager == null)
            {
                Main.Log.LogError("[SmartManager] " + TraductionsManager.GetTraduction("AutomaticPayment_Error"));
                return;
            }

            List<PlayerPaymentData> billDatas = expensesManager.GetBills((PlayerPaymentType)0);
            List<PlayerPaymentData> rentDatas = expensesManager.GetBills((PlayerPaymentType)1);

            billDatas.ForEach(bill => expensesManager.PayBill(bill, false));
            rentDatas.ForEach(rent => expensesManager.PayBill(rent, false));

            DisplayCustomWarning(TraductionsManager.GetTraduction("AutomaticPayment_BillsPaid"));
        }

        private static void DisplayCustomWarning(string message)
        {
            WarningSystem warningSystem = Singleton<WarningSystem>.Instance;

            if (warningSystem == null)
                return;

            warningSystem.RaiseInteractionWarning((InteractionWarningType)0, null);

            GameObject warningCanvas = GameObject.Find("Warning Canvas");
            
            if (warningCanvas == null) return;

            GameObject titleObject = warningCanvas.transform.Find("Interaction Warning/BG/Title")?.gameObject;

            if (titleObject == null) return;

            var titleText = titleObject.GetComponent<TextMeshProUGUI>();
            
            if (titleText != null)
            {
                titleText.text = "<sprite=0> " + message;
            }
        }
    }
}