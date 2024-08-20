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
    
    // Unpause the game back into either intro or in-game states
    public event EventHandler<UnpauseEvent> UnpauseEventHandler;
    
    protected virtual void OnUnpauseEvent(UnpauseEvent @event)
    {
        UnpauseEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeUnpauseEvent(UnpauseEvent @event)
    {
        OnUnpauseEvent(@event);
    }
    
    // Pause the game from intro or in-game
    public event EventHandler<PauseEvent> PauseEventHandler;
    
    protected virtual void OnPauseEvent(PauseEvent @event)
    {
        PauseEventHandler?.Invoke(this, @event);
    }
    
    public void InvokePauseEvent(PauseEvent @event)
    {
        OnPauseEvent(@event);
    }
    
    // Go back to the main menu from the pause menu
    public event EventHandler<QuitToMenuEvent> QuitToMenuEventHandler;
    
    protected virtual void OnQuitToMenuEvent(QuitToMenuEvent @event)
    {
        QuitToMenuEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeQuitToMenuEvent(QuitToMenuEvent @event)
    {
        OnQuitToMenuEvent(@event);
    }
    
    // Game start event
    // When we enter a state that contains a player controller, invoke this event
    public event EventHandler<GameStartEvent> GameStartEventHandler;
    
    protected virtual void OnGameStartEvent(GameStartEvent @event)
    {
        GameStartEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeGameStartEvent(GameStartEvent @event)
    {
        OnGameStartEvent(@event);
    }
    
    // Game stop event
    // When we leave a state that contains a player controller, invoke this event
    public event EventHandler<GameStopEvent> GameStopEventHandler;
    
    protected virtual void OnGameStopEvent(GameStopEvent @event)
    {
        GameStopEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeGameStopEvent(GameStopEvent @event)
    {
        OnGameStopEvent(@event);
    }
    
    // Development event for forcefully entering the arena
    public event EventHandler<DevEnterArenaEvent> DevEnterArenaEventHandler;
    
    protected virtual void OnDevEnterArenaEvent(DevEnterArenaEvent @event)
    {
        DevEnterArenaEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeDevEnterArenaEvent(DevEnterArenaEvent @event)
    {
        OnDevEnterArenaEvent(@event);
    }
    
    // Gameplay // Pre-tutorial // enter main platform from bridge
    public event EventHandler<PreTutorialEnterPlatformEvent> PreTutorialEnterPlatformEventHandler;
    
    protected virtual void OnPreTutorialEnterPlatformEvent(PreTutorialEnterPlatformEvent @event)
    {
        PreTutorialEnterPlatformEventHandler?.Invoke(this, @event);
    }
    
    public void InvokePreTutorialEnterPlatformEvent(PreTutorialEnterPlatformEvent @event)
    {
        OnPreTutorialEnterPlatformEvent(@event);
    }
    
    // Gameplay: When arena orchestrator Start() is called, register arena orchestrator
    public event EventHandler<ArenaOrchestratorRegisterEvent> ArenaOrchestratorRegisterEventHandler;
    
    protected virtual void OnArenaOrchestatorRegisterEvent(ArenaOrchestratorRegisterEvent @event)
    {
        ArenaOrchestratorRegisterEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeArenaOrchestratorRegisterEvent(ArenaOrchestratorRegisterEvent @event)
    {
        OnArenaOrchestatorRegisterEvent(@event);
    }
    
    // Gameplay: Fire event when arena bridge is lowered after entering tutorial zone
    public event EventHandler<ArenaBridgeLoweringCompletedEvent> ArenaBridgeLoweringCompletedEventHandler;
    
    protected virtual void OnArenaBridgeLoweringCompletedEvent(ArenaBridgeLoweringCompletedEvent @event)
    {
        ArenaBridgeLoweringCompletedEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeArenaBridgeLoweringCompletedEvent(ArenaBridgeLoweringCompletedEvent @event)
    {
        OnArenaBridgeLoweringCompletedEvent(@event);
    }
    
    // Gameplay: Fire when the user attempts to press the red button (E)
    public event EventHandler<AttemptPressRedButtonEvent> AttemptPressRedButtonEventHandler;
    
    protected virtual void OnAttemptPressRedButtonEvent(AttemptPressRedButtonEvent @event)
    {
        AttemptPressRedButtonEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeAttemptPressRedButtonEvent(AttemptPressRedButtonEvent @event)
    {
        OnAttemptPressRedButtonEvent(@event);
    }
    
    // Gameplay: Fire event when the red button is pressed in the tutorial
    public event EventHandler<TutorialRedButtonPressedEvent> TutorialRedButtonPressedEventHandler;
    
    protected virtual void OnTutorialRedButtonPressedEvent(TutorialRedButtonPressedEvent @event)
    {
        TutorialRedButtonPressedEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeTutorialRedButtonPressedEvent(TutorialRedButtonPressedEvent @event)
    {
        OnTutorialRedButtonPressedEvent(@event);
    }
    
    // Audio: Fired when a audio source is finished
    public event EventHandler<SoundFinishedEvent> SoundFinishedEventHandler;
    
    protected virtual void OnSoundFinishedEvent(SoundFinishedEvent @event)
    {
        SoundFinishedEventHandler?.Invoke(this, @event);
    }
    
    public void InvokeSoundFinishedEvent(SoundFinishedEvent @event)
    {
        OnSoundFinishedEvent(@event);
    }
}