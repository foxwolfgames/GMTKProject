using FWGameLib.Common.EventSystem;

/// <summary>
///  When we leave a state that contains a player controller, invoke this event
/// </summary>
public class GameStopEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeGameStopEvent(this);
    }
}