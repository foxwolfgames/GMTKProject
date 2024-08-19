public class PauseEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokePauseEvent(this);
    }
}