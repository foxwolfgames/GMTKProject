using FWGameLib.Common.EventSystem;

public class QuitToMenuEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeQuitToMenuEvent(this);
    }
}