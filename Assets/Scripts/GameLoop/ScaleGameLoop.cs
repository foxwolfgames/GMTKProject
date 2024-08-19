public class ScaleGameLoop
{
    public StateMachine GameStateMachine;

    public ScaleGameLoop()
    {
        GameStateMachine = new();
    }

    public void Awake()
    {
        // Initialize game states
        MenuState menuState = new();
        IntroState introState = new();
        InGameState inGameState = new();

        // Initialize transitions
        GameStateMachine.AddTransition(menuState, introState, menuState.CanTransitionPressPlay);
        
        // Set initial state
        GameStateMachine.SetState(menuState);
    }

    public void Update()
    {
        // Run state machine tick
        GameStateMachine.Tick();
    }
}