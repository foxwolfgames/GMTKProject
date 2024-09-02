using FWGameLib.Common.EventSystem;

public class AttemptPressRedButtonEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeAttemptPressRedButtonEvent(this);
    }
}