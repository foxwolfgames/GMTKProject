using FWGameLib.Common.EventSystem;

public class TutorialRedButtonPressedEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeTutorialRedButtonPressedEvent(this);
    }
}