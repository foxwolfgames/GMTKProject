using FWGameLib.Common.EventSystem;
using FWGameLib.InProject.EventSystem;

namespace FWGameLib.Common.AudioSystem.Event
{
    public class ChangeVolumeEvent : IEvent
    {
        public readonly AudioVolumeType AudioVolumeType;

        // From 0.0f -> 1.0f;
        public readonly float VolumePercentage;

        public ChangeVolumeEvent(AudioVolumeType audioVolumeType, float volumePercentage)
        {
            AudioVolumeType = audioVolumeType;
            VolumePercentage = volumePercentage;
        }

        public void Invoke()
        {
            EventRegister.Instance.InvokeChangeVolumeEvent(this);
        }
    }
}