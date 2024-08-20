public class SoundFinishedEvent : IEvent
{
    public Sounds Sound;
    
    public SoundFinishedEvent(Sounds sound)
    {
        Sound = sound;
    }
    
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeSoundFinishedEvent(this);
    }
}