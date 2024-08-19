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

    // Press "Play" button on main menu
    public event EventHandler<PressPlayEvent> PressPlayEventHandler;

    protected virtual void OnPressPlayEvent(PressPlayEvent @event)
    {
        PressPlayEventHandler?.Invoke(this, @event);
    }

    public void InvokePressPlayEvent(PressPlayEvent @event)
    {
        OnPressPlayEvent(@event);
    }

    // Changing the volume on a volume slider
    public event EventHandler<ChangeVolumeEvent> ChangeVolumeEventHandler;

    protected virtual void OnChangeVolumeEvent(ChangeVolumeEvent @event)
    {
        ChangeVolumeEventHandler?.Invoke(this, @event);
    }

    public void InvokeChangeVolumeEvent(ChangeVolumeEvent @event)
    {
        OnChangeVolumeEvent(@event);
    }

    // Forcefully stop a sound
    public event EventHandler<StopSoundEvent> StopSoundEventHandler;

    protected virtual void OnStopSoundEvent(StopSoundEvent @event)
    {
        StopSoundEventHandler?.Invoke(this, @event);
    }

    public void InvokeStopSoundEvent(StopSoundEvent @event)
    {
        OnStopSoundEvent(@event);
    }
}