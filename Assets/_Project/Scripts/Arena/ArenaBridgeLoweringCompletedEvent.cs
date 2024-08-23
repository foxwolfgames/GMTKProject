using FWGameLib.Common.EventSystem;

public class ArenaBridgeLoweringCompletedEvent : IEvent
{
    public ArenaBridge ArenaBridge;
    
    public ArenaBridgeLoweringCompletedEvent(ArenaBridge arenaBridge)
    {
        ArenaBridge = arenaBridge;
    }
    
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeArenaBridgeLoweringCompletedEvent(this);
    }
}