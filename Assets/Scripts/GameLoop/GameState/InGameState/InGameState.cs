using System;

public class InGameState : IState
{
    public bool IsActive = false;
    public bool IsPaused = false;
    
    public InGameState()
    {
        ScaleGame.Instance.EventRegister.PauseEventHandler += OnPauseEvent;
        ScaleGame.Instance.EventRegister.GameStopEventHandler += OnGameStopEvent;
    }
    
    public void Tick()
    {
        if (IsPaused) return;
        if (!IsActive) return;
    }

    public void OnEnter()
    {
        // When entering from being paused, just reset the flag and load as normal
        if (IsPaused)
        {
            // FLOW: PauseState -> InGameState
            IsPaused = false;
            return;
        }
        
        // EXPECTED FLOW: IntroState -> InGameState
        
        // Clean up just in case
        ResetState();
        
        // Designate this state as active in-game state
        IsActive = true;
    }

    public void OnExit()
    {
        // InGameState -> PauseState
        if (IsPaused) return;
        
        // InGameState -> ??? State
        
        // Clean up just in case
        ResetState();
    }

    private void ResetState()
    {
        IsActive = false;
        IsPaused = false;
    }

    public bool CanTransitionPause(PauseState pauseState)
    {
        // The condition for triggering this phase is if we initiate a pause in this state
        if (!IsPaused) return false;
        
        // Set the destination state for when we unpause
        pauseState.PreviousState = this;
        return true;
    }
    
    private void OnPauseEvent(object _, PauseEvent @event)
    {
        // Check if this is the active state to pause from
        if (!IsActive) return;
        IsPaused = true;
    }

    private void OnGameStopEvent(object _, GameStopEvent @event)
    {
        ResetState();
    }
}