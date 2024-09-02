using FWGameLib.Common.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : IState
{
    public IState PreviousState;
    public bool IsActive = false;
    public bool ShouldUnpause = false;
    public bool ShouldQuitToMenu = false;

    public PauseState()
    {
        ScaleGame.Instance.EventRegister.UnpauseEventHandler += OnUnpauseEvent;
        ScaleGame.Instance.EventRegister.QuitToMenuEventHandler += OnQuitToMenuEvent;
    }
    
    public void Tick()
    {
        // Do nothing
    }

    public void OnEnter()
    {
        // NOTE: We expect previous state to already be set by the time we enter the pause menu
        
        Debug.Log("Game paused");
        Time.timeScale = 0f;
        // NOTE: This actually stops all audio sources (we don't want this!!!)
        // AudioListener.pause = true;
        IsActive = true;
    }

    public void OnExit()
    {
        if (ShouldQuitToMenu)
        {
            ResetState();
            return;
        }

        Debug.Log("Game unpaused");
        Time.timeScale = 1f;
        // AudioListener.pause = false;
        ResetState();
    }

    private void ResetState()
    {
        IsActive = false;
        ShouldUnpause = false;
        PreviousState = null;
        ShouldQuitToMenu = false;
    }

    public bool CanTransitionUnpause(IState destinationState)
    {
        return ShouldUnpause && destinationState == PreviousState;
    }

    public bool CanTransitionQuitToMenu()
    {
        if (ShouldQuitToMenu)
        {
            // TODO: refactor this
            ScaleGame.Instance.LoadSceneAsyncAndStopAllAudioSources(Scenes.MAIN_MENU);
            new GameStopEvent().Invoke();
            Time.timeScale = 1f;
            return true;
        }

        return false;
    }
    
    private void OnUnpauseEvent(object _, UnpauseEvent @event)
    {
        // Check if we are actually in the pause menu
        if (!IsActive) return;

        ShouldUnpause = true;
    }
    
    private void OnQuitToMenuEvent(object _, QuitToMenuEvent @event)
    {
        // Check if we are actually in the pause menu
        if (!IsActive) return;

        ShouldQuitToMenu = true;
    }
}