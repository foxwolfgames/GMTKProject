public class ScaleGameLoop
{
    public StateMachine GameStateMachine = new();

    private MenuState _menuState;
    private IntroState _introState;
    private InGameState _inGameState;
    private PauseState _pauseState;

    public void Awake()
    {
        // Initialize game states
        _menuState = new MenuState();
        _introState = new IntroState();
        _inGameState = new InGameState();
        _pauseState = new PauseState();

        // Initialize transitions
        GameStateMachine.AddTransition(_menuState, _introState, _menuState.CanTransitionPressPlay);
        GameStateMachine.AddTransition(_introState, _pauseState, () => _introState.CanTransitionPause(_pauseState));
        GameStateMachine.AddTransition(_inGameState, _pauseState, () => _inGameState.CanTransitionPause(_pauseState));
        GameStateMachine.AddTransition(_pauseState, _introState, () => _pauseState.CanTransitionUnpause(_introState));
        GameStateMachine.AddTransition(_pauseState, _inGameState, () => _pauseState.CanTransitionUnpause(_inGameState));

        // Set initial state
        GameStateMachine.SetState(_menuState);
    }

    public void Update()
    {
        // Run state machine tick
        GameStateMachine.Tick();
    }
}