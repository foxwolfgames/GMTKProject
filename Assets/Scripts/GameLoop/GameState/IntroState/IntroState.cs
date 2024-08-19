using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroState : IState
{
    private Vector3 _crowdAmbiencePosition = new(0, 10, 0);
    
    public bool IsActive = false;
    public bool IsPaused = false;
    
    public IntroState()
    {
        ScaleGame.Instance.EventRegister.PauseEventHandler += OnPauseEvent;
    }
    
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

        // EXPECTED FLOW: MenuState -> IntroState
        
        // Designate this state as active in-game state
        IsActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_AMBIENCE_INTRO_AREA_CROWD, _crowdAmbiencePosition);
    }

    public void OnExit()
    {
        // Don't do anything if we are transitioning to the PauseState
        if (IsPaused) return;

        // Designate this state as inactive
        IsActive = false;
        new StopSoundEvent(Sounds.SFX_AMBIENCE_INTRO_AREA_CROWD).Invoke();
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