/// <summary>
/// When we enter a state that contains a player controller, invoke this event
/// </summary>
public class GameStartEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeGameStartEvent(this);
    }
}