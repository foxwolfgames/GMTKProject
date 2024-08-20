public class TutorialState : IState
{
    private GameManager _gameManager;
    private bool _bridgeLoweringCompleted = false;
    private bool _redButtonPressed = false;

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
    }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.TutorialRedButtonPressedEventHandler += OnTutorialRedButtonPressedEvent;
        ScaleGame.Instance.EventRegister.ArenaBridgeLoweringCompletedEventHandler += OnBridgeLoweringCompletedEvent;
        _gameManager.ArenaOrchestrator.bridge.LowerBridge();
    }

    public void OnExit()
    {
        ResetState();
        new StopSoundEvent(Sounds.MUSIC_GAME_TUTORIAL).Invoke();
        ScaleGame.Instance.EventRegister.ArenaBridgeLoweringCompletedEventHandler -= OnBridgeLoweringCompletedEvent;
        ScaleGame.Instance.EventRegister.TutorialRedButtonPressedEventHandler -= OnTutorialRedButtonPressedEvent;
    }

    public void ResetState()
    {
        _bridgeLoweringCompleted = false;
        _redButtonPressed = false;
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
}