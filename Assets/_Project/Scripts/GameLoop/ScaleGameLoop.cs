using FWGameLib.Common.StateMachine;

public class ScaleGameLoop
{
    public readonly StateMachine GameStateMachine = new();

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
        _inGameState.Awake();
        _pauseState = new PauseState();

        // Initialize transitions
        GameStateMachine.AddTransition(_menuState, _introState, _menuState.CanTransitionPressPlay);
        GameStateMachine.AddTransition(_introState, _pauseState, () => _introState.CanTransitionPause(_pauseState));
        GameStateMachine.AddTransition(_inGameState, _pauseState, () => _inGameState.CanTransitionPause(_pauseState));
        GameStateMachine.AddTransition(_pauseState, _introState, () => _pauseState.CanTransitionUnpause(_introState));
        GameStateMachine.AddTransition(_pauseState, _inGameState, () => _pauseState.CanTransitionUnpause(_inGameState));
        GameStateMachine.AddTransition(_pauseState, _menuState, _pauseState.CanTransitionQuitToMenu);
        GameStateMachine.AddTransition(_introState, _inGameState, _introState.CanTransitionDevEnterArena);
        GameStateMachine.AddTransition(_inGameState, _menuState, _inGameState.CanTransitionGameOverQuitToMenu);

        // Set initial state
        GameStateMachine.SetState(_menuState);
    }

    public void Update()
    {
        // Run state machine tick
        GameStateMachine.Tick();
    }
}