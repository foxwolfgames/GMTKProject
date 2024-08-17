using System;

// Must be attached to master game object

public class EventRegister
{
    public event EventHandler<TestItemScaleBoardUpdateEvent> TestItemScaleBoardUpdateEventHandler;

    protected virtual void OnTestItemScaleBoardUpdateEvent(TestItemScaleBoardUpdateEvent e)
    {
        TestItemScaleBoardUpdateEventHandler?.Invoke(this, e);
    }
        
    public void InvokeTestItemScaleBoardUpdateEvent(TestItemScaleBoardUpdateEvent e)
    {
        OnTestItemScaleBoardUpdateEvent(e);
    }
}