public class PressPlayEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokePressPlayEvent(this);
    }
}