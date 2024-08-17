using System;

// Must be attached to master game object

public class EventRegister
{
    public event EventHandler<TestItemScaleBoardUpdateEvent> TestItemScaleBoardUpdateEventHandler;

    protected virtual void OnTestItemScaleBoardUpdateEvent(TestItemScaleBoardUpdateEvent @event)
    {
        TestItemScaleBoardUpdateEventHandler?.Invoke(this, @event);
    }
        
    public void InvokeTestItemScaleBoardUpdateEvent(TestItemScaleBoardUpdateEvent @event)
    {
        OnTestItemScaleBoardUpdateEvent(@event);
    }
}