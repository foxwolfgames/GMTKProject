using FWGameLib.Common.EventSystem;

public class PressPlayEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokePressPlayEvent(this);
    }
}