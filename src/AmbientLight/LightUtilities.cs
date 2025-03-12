using System;
using UnityEngine;
using TMPro;
using SmartManager.Manager;

namespace SmartManager.AmbientLight
{
    public class LightScheduler
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public bool IsAM { get; private set; }
        private string _lastTime;

        public LightScheduler(string initialTime)
        {
            UpdateTime(initialTime);
        }

        public void UpdateTime(string newTime)
        {
            if (_lastTime != newTime && IsValidTimeFormat(newTime))
            {
                ParseTime(newTime);
                _lastTime = newTime;
            }
        }

        public bool ShouldActivateLights(DayCycleManager dayCycle)
        {
            if (dayCycle == null)
            {
                Debug.LogError("[SmartManager] " + TraductionsManager.GetTraduction("AmbientLight_DayCycleManagerNotFound"));
                return false;
            }

            return dayCycle.CurrentHour == Hour &&
                   dayCycle.CurrentMinute == Minute &&
                   dayCycle.AM == IsAM;
        }

        private void ParseTime(string time)
        {
            string[] parts = time.Split(':');
            if (parts.Length == 2 && int.TryParse(parts[0], out var hour) && int.TryParse(parts[1], out var minute))
            {
                Hour = hour;
                Minute = minute;

                if (Hour < 8 || Hour > 21)
                {
                    Debug.Log("[SmartManager] " + TraductionsManager.GetTraduction("AmbientLight_InvalidTime"));
                    Hour = 18;
                    Minute = 0;
                }

                IsAM = Hour <= 12;
                if (Hour > 12) Hour -= 12;
            }
            else
            {
                throw new FormatException($"Invalid time format: {time}");
            }
        }

        private bool IsValidTimeFormat(string time)
        {
            return TimeSpan.TryParse(time, out _);
        }

        public override string ToString()
        {
            return $"{Hour:D2}:{Minute:D2}";
        }
    }

    public class LightActivator
    {
        private LightSwitch[] _lightSwitches;

        public void InitializeLights()
        {
            _lightSwitches = UnityEngine.Object.FindObjectsByType<LightSwitch>(FindObjectsSortMode.None);
        }

        public void ActivateLights()
        {
            foreach (var lightSwitch in _lightSwitches)
            {
                if (ShouldActivate(lightSwitch))
                {
                    lightSwitch.InstantInteract();
                }
            }
        }

        private bool ShouldActivate(LightSwitch lightSwitch)
        {
            var storeLightManager = StoreLightManager.Instance;
            return storeLightManager != null && !storeLightManager.TurnOn && lightSwitch.isActiveAndEnabled;
        }
    }

    public static class WarningDisplayer
    {
        public static void DisplayWarning(string message)
        {
            WarningSystem warningSystem = WarningSystem.Instance;

            if (warningSystem == null) return;

            warningSystem.RaiseInteractionWarning((InteractionWarningType)0, null);

            GameObject warningCanvas = GameObject.Find("Warning Canvas");
            
            if (warningCanvas == null) return;

            GameObject titleObject = warningCanvas.transform.Find("Interaction Warning/BG/Title")?.gameObject;

            if (titleObject == null) return;

            TextMeshProUGUI titleText = titleObject.GetComponent<TextMeshProUGUI>();
            
            if (titleText != null)
            {
                titleText.text = "<sprite=0> " + message;
            }
        }
    }
}
