using System;
using FWGameLib.Common.AudioSystem.Event;

namespace FWGameLib.InProject.EventSystem
{
    /// <summary>
    /// The register for all events in the game. Must be initialized by a singleton master game object.
    /// This class should be edited per-project that uses FWGameLib.
    /// </summary>
    public class EventRegister
    {
        public static EventRegister Instance { get; private set; }
        
        public EventRegister()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                // throw new Exception("EventRegister is a singleton and cannot be instantiated more than once.");
            }
        }
        
        /// <summary>
        /// Changing the volume on a volume slider
        /// FWGL built-in event
        /// </summary>
        public event EventHandler<FWGLChangeVolumeEvent> FWGLChangeVolumeEventHandler;
        public void Invoke(FWGLChangeVolumeEvent @event)
        {
            FWGLChangeVolumeEventHandler?.Invoke(this, @event);
        }
        
        /// <summary>
        /// AudioSystem: Fired when a audio source is finished
        /// FWGL built-in event
        /// </summary>
        public event EventHandler<FWGLSoundFinishedEvent> FWGLSoundFinishedEventHandler;
        public void Invoke(FWGLSoundFinishedEvent @event)
        {
            FWGLSoundFinishedEventHandler?.Invoke(this, @event);
        }
        
        /// <summary>
        /// AudioSystem: Forcefully stop a sound
        /// FWGL built-in event
        /// </summary>
        public event EventHandler<FWGLStopSoundEvent> FWGLStopSoundEventHandler;
        public void Invoke(FWGLStopSoundEvent @event)
        {
            FWGLStopSoundEventHandler?.Invoke(this, @event);
        }
        
        /// <summary>
        /// AudioSystem: Call when pausing audio that is paused with the game
        /// FWGL built-in event
        /// </summary>
        public event EventHandler<FWGLAudioPauseEvent> FWGLAudioPauseEventHandler;
        public void Invoke(FWGLAudioPauseEvent @event)
        {
            FWGLAudioPauseEventHandler?.Invoke(this, @event);
        }
        
        /// <summary>
        /// AudioSystem: Call when unpausing audio that is paused with the game
        /// FWGL built-in event
        /// </summary>
        public event EventHandler<FWGLAudioUnpauseEvent> FWGLAudioUnpauseEventHandler;
        public void Invoke(FWGLAudioUnpauseEvent @event)
        {
            FWGLAudioUnpauseEventHandler?.Invoke(this, @event);
        }
        
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
    
        // Gameplay: Fell into void
        public event EventHandler<FallIntoVoidEvent> FallIntoVoidEventHandler;
    
        protected virtual void OnFallIntoVoidEvent(FallIntoVoidEvent @event)
        {
            FallIntoVoidEventHandler?.Invoke(this, @event);
        }
    
        public void InvokeFallIntoVoidEvent(FallIntoVoidEvent @event)
        {
            OnFallIntoVoidEvent(@event);
        }
    
        // Gameplay: Game over event
        public event EventHandler<GameOverEvent> GameOverEventHandler;
    
        protected virtual void OnGameOverEvent(GameOverEvent @event)
        {
            GameOverEventHandler?.Invoke(this, @event);
        }
    
        public void InvokeGameOverEvent(GameOverEvent @event)
        {
            OnGameOverEvent(@event);
        }
    
        // Gameplay: Boss advance event
        public event EventHandler<BossAdvanceEvent> BossAdvanceEventHandler;
    
        protected virtual void OnBossAdvanceEvent(BossAdvanceEvent @event)
        {
            BossAdvanceEventHandler?.Invoke(this, @event);
        }
    
        public void InvokeBossAdvanceEvent(BossAdvanceEvent @event)
        {
            OnBossAdvanceEvent(@event);
        }
    }
}