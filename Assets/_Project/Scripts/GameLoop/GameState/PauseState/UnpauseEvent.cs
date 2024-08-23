public class UnpauseEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeUnpauseEvent(this);
    }
}