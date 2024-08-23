public class PreTutorialEnterPlatformEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokePreTutorialEnterPlatformEvent(this);
    }
}