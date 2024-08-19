using UnityEngine.SceneManagement;

public class IntroState : IState
{
    public bool IsPaused = false;
    
    public void Tick()
    {
        // Stop ticking on Pause
        if (IsPaused) return;
    }

    public void OnEnter()
    {
        // When entering from being paused, just reset the flag and load as normal
        if (IsPaused)
        {
            IsPaused = false;
            return;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnExit()
    {
        // Don't do anything if we are transitioning to the PauseState
        if (IsPaused) return;
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