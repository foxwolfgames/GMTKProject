public class AttemptPressRedButtonEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeAttemptPressRedButtonEvent(this);
    }
}