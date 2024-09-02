using FWGameLib.Common.AudioSystem.Event;
using FWGameLib.Common.StateMachine;
using FWGameLib.InProject.AudioSystem;
using UnityEngine;

public class SurvivalState : IState
{
    private const float WindupTime = 12f;
    private const float SurvivalTime = 60f;

    private GameManager _gameManager;
    public float TimeElapsed = 0f;
    public bool IsWindingUp => TimeElapsed < WindupTime;
    
    public SurvivalState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    
    public void Tick()
    {
        TimeElapsed += Time.deltaTime;
        if (IsWindingUp) return;

        _gameManager.ArenaOrchestrator.itemLauncher.isLaunching = true;
        // Main game loop
        float timeRemaining = SurvivalTime - (TimeElapsed - WindupTime);
        int seconds = Mathf.FloorToInt(timeRemaining % SurvivalTime);
        // TODO: Display this on jumbotron?
    }

    public void OnEnter()
    {
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_GAME_PHASE_0);
        ScaleGame.Instance.Audio.PlaySound(Sounds.VOICE_ANNOUNCER_SURVIVAL_ENTRY);
        _gameManager.ArenaOrchestrator.platform.SetRedButtonPosition(RedButtonPositions.INACTIVE);
        _gameManager.ArenaOrchestrator.platform.SetPlatformCanRotate(true);
    }

    public void OnExit()
    {
        ResetState();
        new FWGLStopSoundEvent(Sounds.MUSIC_GAME_PHASE_0).Invoke();
        new FWGLStopSoundEvent(Sounds.VOICE_ANNOUNCER_SURVIVAL_ENTRY).Invoke();
    }

    public void ResetState()
    {
        TimeElapsed = 0f;
    }

    public bool CanTransitionTimeElapsed()
    {
        return TimeElapsed > SurvivalTime + WindupTime;
    }
}