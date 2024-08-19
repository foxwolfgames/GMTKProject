public class ChangeVolumeEvent : IEvent
{
    public readonly AudioType AudioType;
    // From 0.0f -> 1.0f;
    public readonly float VolumePercentage;

    public ChangeVolumeEvent(AudioType audioType, float volumePercentage)
    {
        AudioType = audioType;
        VolumePercentage = volumePercentage;
    }
    
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeChangeVolumeEvent(this);
    }
}