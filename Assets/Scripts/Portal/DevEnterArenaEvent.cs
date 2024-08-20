public class DevEnterArenaEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeDevEnterArenaEvent(this);
    }
}