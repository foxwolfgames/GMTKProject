using FWGameLib.Common.EventSystem;

public class GameOverEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeGameOverEvent(this);
    }
}
    
