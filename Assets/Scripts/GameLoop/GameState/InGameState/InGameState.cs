using System;

public class InGameState : IState
{
    public bool IsPaused = false;
    
    public void Tick()
    {
        throw new NotImplementedException();
    }

    public void OnEnter()
    {
        throw new NotImplementedException();
    }

    public void OnExit()
    {
        throw new NotImplementedException();
    }

    public bool CanTransitionPause(PauseState pauseState)
    {
        // The condition for triggering this phase is if we initiate a pause in this state
        if (!IsPaused) return false;
        
        // Set the destination state for when we unpause
        pauseState.PreviousState = this;
        return true;
    }
}