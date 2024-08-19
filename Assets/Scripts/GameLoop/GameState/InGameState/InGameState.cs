using System;

public class InGameState : IState
{
    public bool IsActive = false;
    public bool IsPaused = false;
    
    public InGameState()
    {
        ScaleGame.Instance.EventRegister.PauseEventHandler += OnPauseEvent;
    }
    
    public void Tick()
    {
        //throw new NotImplementedException();
    }

    public void OnEnter()
    {
        if (IsPaused)
        {
            IsPaused = false;
            return;
        }
        
        // EXPECTED FLOW: IntroState -> InGameState
        
        // Designate this state as active in-game state
        IsActive = true;
    }

    public void OnExit()
    {
        if (IsPaused) return;
        
        IsActive = false;
        ResetState();
    }

    private void ResetState()
    {
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
}