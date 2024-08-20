public class BossAdvanceEvent : IEvent
{
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeBossAdvanceEvent(this);
    }
}