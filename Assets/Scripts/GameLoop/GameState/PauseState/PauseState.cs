using UnityEngine;

public class PauseState : IState
{
    public IState PreviousState;
    public bool IsActive = false;
    public bool ShouldUnpause = false;

    public PauseState()
    {
        ScaleGame.Instance.EventRegister.UnpauseEventHandler += OnUnpauseEvent;
    }
    
    public void Tick()
    {
        // Do nothing
    }

    public void OnEnter()
    {
        Debug.Log("Game paused");
        Time.timeScale = 0f;
        AudioListener.pause = true;
        IsActive = true;
    }

    public void OnExit()
    {
        Debug.Log("Game unpaused");
        Time.timeScale = 1f;
        AudioListener.pause = false;
        IsActive = false;
        ResetState();
    }

    private void ResetState()
    {
        ShouldUnpause = false;
        PreviousState = null;
    }

    public bool CanTransitionUnpause(IState destinationState)
    {
        // Don't unpause if we aren't supposed to
        if (!ShouldUnpause) return false;
        
        // Don't allow this transition if we are testing the transition to unpause for another state
        if (destinationState != PreviousState) return false;

        return true;
    }
    
    private void OnUnpauseEvent(object _, UnpauseEvent @event)
    {
        // Check if we are actually in the pause menu
        if (!IsActive) return;

        ShouldUnpause = true;
    }
}