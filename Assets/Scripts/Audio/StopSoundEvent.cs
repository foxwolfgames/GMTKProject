public class StopSoundEvent : IEvent
{
    public Sounds SoundName;
    
    public StopSoundEvent(Sounds soundName)
    {
        SoundName = soundName;
    }
    
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeStopSoundEvent(this);
    }
}