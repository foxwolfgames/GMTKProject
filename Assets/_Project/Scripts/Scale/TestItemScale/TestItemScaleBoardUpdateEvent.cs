public class TestItemScaleBoardUpdateEvent : IEvent
{
    public readonly int NumItems;
    public readonly float TotalMass;

    public TestItemScaleBoardUpdateEvent(int numItems, float totalMass)
    {
        NumItems = numItems;
        TotalMass = totalMass;
    }

    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeTestItemScaleBoardUpdateEvent(this);
    }
}