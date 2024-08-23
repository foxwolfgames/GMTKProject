using System.Collections;
using FWGameLib.Common.AudioSystem.Event;
using FWGameLib.Common.StateMachine;
using FWGameLib.InProject.AudioSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroState : IState
{
    private Vector3 _crowdAmbiencePosition = new(0, 10, 0);
    
    private const float TimeBetweenVoiceLines = 10f;
    public bool IsActive = false;
    public bool IsPaused = false;
    public bool Dev_ShouldEnterArena = false;
    private float _timeSinceLastVoiceLine = 0f;
    private float _timeElapsed = 0f;
    private bool _hasPlayedFirstVoiceLine = false;
    
    public IntroState()
    {
        ScaleGame.Instance.EventRegister.PauseEventHandler += OnPauseEvent;
        ScaleGame.Instance.EventRegister.GameStopEventHandler += OnGameStopEvent;
        ScaleGame.Instance.EventRegister.DevEnterArenaEventHandler += OnDevEnterArenaEvent;
    }
    
    public void Tick()
    {
        // Stop ticking on Pause
        if (IsPaused) return;
        
        // Stop ticking if this state is not active
        if (!IsActive) return;
        
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed > 2f && !_hasPlayedFirstVoiceLine)
        {
            _hasPlayedFirstVoiceLine = true;
            ScaleGame.Instance.Audio.PlaySound(Sounds.VOICE_ANNOUNCER_ENTER_LOBBY, _crowdAmbiencePosition);
        }
        
        _timeSinceLastVoiceLine += Time.deltaTime;
        if (_timeSinceLastVoiceLine >= TimeBetweenVoiceLines)
        {
            _timeSinceLastVoiceLine = 0f;
            ScaleGame.Instance.Audio.PlaySound(Sounds.VOICE_ANNOUNCER_LOBBY_IDLE, _crowdAmbiencePosition);
        }
    }

    public void OnEnter()
    {
        // When entering from being paused, just reset the flag and load as normal
        if (IsPaused)
        {
            // FLOW: PauseState -> IntroState
            IsPaused = false;
            return;
        }
        
        // EXPECTED FLOW: MenuState -> IntroState
        
        // Clean up just in case
        ResetState();
        
        // Designate this state as active in-game state
        IsActive = true;
        new GameStartEvent().Invoke();
        ScaleGame.Instance.LoadSceneAsyncAndStopAllAudioSources(Scenes.LOBBY);
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_AMBIENCE_INTRO_AREA_CROWD, _crowdAmbiencePosition);
    }

    public void OnExit()
    {
        // Don't do anything if we are transitioning to the PauseState
        if (IsPaused) return;
        
        // EXPECTED FLOW: IntroState -> InGameState

        // Designate this state as inactive
        IsActive = false;
        new StopSoundEvent(Sounds.SFX_AMBIENCE_INTRO_AREA_CROWD).Invoke();
        new StopSoundEvent(Sounds.VOICE_ANNOUNCER_LOBBY_IDLE).Invoke();
        new StopSoundEvent(Sounds.VOICE_ANNOUNCER_ENTER_LOBBY).Invoke();
        ResetState();
    }

    private void ResetState()
    {
        IsActive = false;
        IsPaused = false;
        Dev_ShouldEnterArena = false;
        _timeSinceLastVoiceLine = 0f;
        _timeElapsed = 0f;
        _hasPlayedFirstVoiceLine = false;
    }

    public bool CanTransitionPause(PauseState pauseState)
    {
        // The condition for triggering this phase is if we initiate a pause in this state
        if (!IsPaused) return false;
        
        // Set the destination state for when we unpause
        pauseState.PreviousState = this;
        return true;
    }

    public bool CanTransitionDevEnterArena()
    {
        return Dev_ShouldEnterArena;
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
        new StopSoundEvent(Sounds.SFX_AMBIENCE_INTRO_AREA_CROWD).Invoke();
        new StopSoundEvent(Sounds.VOICE_ANNOUNCER_LOBBY_IDLE).Invoke();
        new StopSoundEvent(Sounds.VOICE_ANNOUNCER_ENTER_LOBBY).Invoke();
    }

    public void OnDevEnterArenaEvent(object _, DevEnterArenaEvent @event)
    {
        Dev_ShouldEnterArena = true;
    }
}