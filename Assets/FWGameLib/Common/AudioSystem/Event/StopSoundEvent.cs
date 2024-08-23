using FWGameLib.Common.EventSystem;
using FWGameLib.InProject.AudioSystem;
using FWGameLib.InProject.EventSystem;

namespace FWGameLib.Common.AudioSystem.Event
{
    public class StopSoundEvent : IEvent
    {
        public Sounds SoundName;

        public StopSoundEvent(Sounds soundName)
        {
            SoundName = soundName;
        }

        public void Invoke()
        {
            EventRegister.Instance.InvokeStopSoundEvent(this);
        }
    }
}