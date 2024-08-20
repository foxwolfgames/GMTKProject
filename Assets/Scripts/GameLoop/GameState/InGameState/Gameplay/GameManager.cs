public class GameManager
{
    public readonly StateMachine StateMachine;
    public ArenaOrchestrator ArenaOrchestrator;

    private PreGameState _preGameState;
    private PreTutorialState _preTutorialState;
    private TutorialState _tutorialState;
    private SurvivalState _survivalState;
    private BossPhaseState _bossPhaseState;
    private GameOverState _gameOverState;

    // Set to true or false depending on result before setting IsGameOver
    public bool IsVictory = false;
    public bool IsGameOver = false;

    public GameManager()
    {
        StateMachine = new StateMachine();
        ScaleGame.Instance.EventRegister.GameStopEventHandler += OnGameStopEvent;
    }

    public void Awake()
    {
        // Initialize states
        _preGameState = new PreGameState();
        _preTutorialState = new PreTutorialState(this);
        _tutorialState = new TutorialState(this);
        _survivalState = new SurvivalState(this);
        _bossPhaseState = new BossPhaseState(this);
        _gameOverState = new GameOverState(this);

        // Initialize transitions
        StateMachine.AddTransition(_preTutorialState, _tutorialState, _preTutorialState.CanTransitionEnterPlatform);
        StateMachine.AddTransition(_tutorialState, _survivalState, _tutorialState.CanTransitionRedButtonPressed);

        StateMachine.AddAnyTransition(_gameOverState, CanTransitionGameOver);
    }

    public void Start()
    {
        StateMachine.SetState(_preTutorialState);
        ScaleGame.Instance.EventRegister.ArenaOrchestratorRegisterEventHandler += OnArenaOrchestratorRegisterEvent;
    }

    public void Update()
    {
        StateMachine.Tick();
    }

    public void ResetState()
    {
        IsVictory = false;
        IsGameOver = false;
        _preTutorialState.ResetState();
        _tutorialState.ResetState();
    }

    private bool CanTransitionGameOver()
    {
        return IsGameOver;
    }

    private void OnArenaOrchestratorRegisterEvent(object _, ArenaOrchestratorRegisterEvent @event)
    {
        ArenaOrchestrator = @event.ArenaOrchestrator;
    }
    
    private void OnGameStopEvent(object _, GameStopEvent @event)
    {
        StateMachine.SetState(_preGameState);
    }
}