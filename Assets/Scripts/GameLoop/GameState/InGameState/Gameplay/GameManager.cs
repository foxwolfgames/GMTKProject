using System;

public class GameManager
{
    public readonly StateMachine StateMachine;
    public ArenaOrchestrator ArenaOrchestrator;

    private PreGameState _preGameState;
    private PreTutorialState _preTutorialState;
    private TutorialState _tutorialState;

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

        // Initialize transitions
        StateMachine.AddTransition(_preTutorialState, _tutorialState, _preTutorialState.CanTransitionEnterPlatform);
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
        _preTutorialState.ResetState();
        _tutorialState.ResetState();
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