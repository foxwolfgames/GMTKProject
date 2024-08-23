using FWGameLib.Common.EventSystem;
using FWGameLib.InProject.AudioSystem;
using FWGameLib.InProject.EventSystem;

namespace FWGameLib.Common.AudioSystem.Event
{
    public class SoundFinishedEvent : IEvent
    {
        public Sounds Sound;
    
        public SoundFinishedEvent(Sounds sound)
        {
            Sound = sound;
        }
    
        public void Invoke()
        {
            EventRegister.Instance.InvokeSoundFinishedEvent(this);
        }
    }
}