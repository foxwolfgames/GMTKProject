using System;

// Must be attached to master game object

public class EventRegister
{
    // 
    public event EventHandler<TestItemScaleBoardUpdateEvent> TestItemScaleBoardUpdateEventHandler;

    protected virtual void OnTestItemScaleBoardUpdateEvent(TestItemScaleBoardUpdateEvent @event)
    {
        TestItemScaleBoardUpdateEventHandler?.Invoke(this, @event);
    }
        
    public void InvokeTestItemScaleBoardUpdateEvent(TestItemScaleBoardUpdateEvent @event)
    {
        OnTestItemScaleBoardUpdateEvent(@event);
    }

    // 
    public event EventHandler<ScaleDetectionZoneEnterEvent> ScaleDetectionZoneEnterEventHandler;

    protected virtual void OnScaleDetectionZoneEnterEvent(ScaleDetectionZoneEnterEvent @event)
    {
        ScaleDetectionZoneEnterEventHandler?.Invoke(this, @event);
    }

    public void InvokeScaleDetectionZoneEnterEvent(ScaleDetectionZoneEnterEvent @event)
    {
        OnScaleDetectionZoneEnterEvent(@event);
    }

    // 
    public event EventHandler<ScaleDetectionZoneExitEvent> ScaleDetectionZoneExitEventHandler;

    protected virtual void OnScaleDetectionZoneExitEvent(ScaleDetectionZoneExitEvent @event)
    {
        ScaleDetectionZoneExitEventHandler?.Invoke(this, @event);
    }

    public void InvokeScaleDetectionZoneExitEvent(ScaleDetectionZoneExitEvent @event)
    {
        OnScaleDetectionZoneExitEvent(@event);
    }
    
    // Note Shatter
    public event EventHandler<NoteShatterEvent> NoteShatterEventHandler;

    protected virtual void OnNoteShatterEvent(NoteShatterEvent @event)
    {
        NoteShatterEventHandler?.Invoke(this, @event);
    }

    public void InvokeNoteShatterEvent(NoteShatterEvent @event)
    {
        OnNoteShatterEvent(@event);
    }
}