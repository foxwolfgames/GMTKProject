using UnityEngine;

public class TutorialState : IState
{
    private const float TimeBetweenVoiceLines = 20f;
    private GameManager _gameManager;
    private bool _bridgeLoweringCompleted = false;
    private bool _redButtonPressed = false;
    // 5 seconds before next voice line
    private float _timeSinceLastVoiceLine = 15f;

    // MARK: While bridge is lowering, camera should shake
    private bool CameraShouldShake => !_bridgeLoweringCompleted;
    
    public TutorialState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Tick()
    {
        if (CameraShouldShake)
        {
            // TODO: Make camera shake
        }

        if (_bridgeLoweringCompleted)
        {
            _timeSinceLastVoiceLine += Time.deltaTime;
            if (_timeSinceLastVoiceLine >= TimeBetweenVoiceLines)
            {
                _timeSinceLastVoiceLine = 0f;
                ScaleGame.Instance.Audio.PlaySound(Sounds.VOICE_ANNOUNCER_TUTORIAL_IDLE);
            }
        }
    }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.TutorialRedButtonPressedEventHandler += OnTutorialRedButtonPressedEvent;
        ScaleGame.Instance.EventRegister.ArenaBridgeLoweringCompletedEventHandler += OnBridgeLoweringCompletedEvent;
        ScaleGame.Instance.EventRegister.GameStopEventHandler += OnGameStopEvent;
        _gameManager.ArenaOrchestrator.bridge.LowerBridge();
    }

    public void OnExit()
    {
        ResetState();
        new StopSoundEvent(Sounds.MUSIC_GAME_TUTORIAL).Invoke();
        ScaleGame.Instance.EventRegister.GameStopEventHandler -= OnGameStopEvent;
        ScaleGame.Instance.EventRegister.ArenaBridgeLoweringCompletedEventHandler -= OnBridgeLoweringCompletedEvent;
        ScaleGame.Instance.EventRegister.TutorialRedButtonPressedEventHandler -= OnTutorialRedButtonPressedEvent;
    }

    public void ResetState()
    {
        _bridgeLoweringCompleted = false;
        _redButtonPressed = false;
        _timeSinceLastVoiceLine = 25f;
    }

    public bool CanTransitionRedButtonPressed()
    {
        return _redButtonPressed;
    }
    
    private void OnBridgeLoweringCompletedEvent(object _, ArenaBridgeLoweringCompletedEvent @event)
    {
        _bridgeLoweringCompleted = true;
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_GAME_TUTORIAL);
        _gameManager.ArenaOrchestrator.platform.SetRedButtonPosition(RedButtonPositions.SKIP_TUTORIAL);
        _gameManager.ArenaOrchestrator.dialogueController.PlayNarrative();
    }
    
    private void OnTutorialRedButtonPressedEvent(object _, TutorialRedButtonPressedEvent @event)
    {
        _redButtonPressed = true;
    }
    
    private void OnGameStopEvent(object _, GameStopEvent @event)
    {
        new StopSoundEvent(Sounds.VOICE_ANNOUNCER_TUTORIAL_IDLE).Invoke();
    }
}