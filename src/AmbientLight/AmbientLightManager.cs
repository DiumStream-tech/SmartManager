using UnityEngine;
using SmartManager.Manager;

namespace SmartManager.AmbientLight
{
    public class AmbientLightManager : MonoBehaviour
    {
        private LightScheduler _scheduler;
        private LightActivator _activator;

        private void Awake()
        {
            _scheduler = new LightScheduler(Main.TimeToSwitch.Value);
            _activator = new LightActivator();
        }

        private void Start()
        {
            _activator.InitializeLights();
            Debug.Log($"[SmartManager] {TraductionsManager.GetTraduction("AmbientLight_Ready")} {_scheduler}");
        }

        private void Update()
        {
            _scheduler.UpdateTime(Main.TimeToSwitch.Value);

            if (_scheduler.ShouldActivateLights(DayCycleManager.Instance))
            {
                _activator.ActivateLights();
                WarningDisplayer.DisplayWarning(TraductionsManager.GetTraduction("AmbientLight_LightsOn"));
            }
        }
    }
}
