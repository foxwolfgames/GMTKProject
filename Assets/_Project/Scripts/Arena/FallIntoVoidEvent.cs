public class FallIntoVoidEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeFallIntoVoidEvent(this);
    }
}