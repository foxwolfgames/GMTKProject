public class PreTutorialState : IState
{
    private GameManager _gameManager;
    public bool HasEnteredPlatform = false;

    public PreTutorialState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Tick()
    {
        // throw new System.NotImplementedException();
    }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.PreTutorialEnterPlatformEventHandler += OnPreTutorialEnterPlatformEvent;
    }

    public void OnExit()
    {
        ScaleGame.Instance.EventRegister.PreTutorialEnterPlatformEventHandler -= OnPreTutorialEnterPlatformEvent;
    }

    public void ResetState()
    {
        HasEnteredPlatform = false;
    }
    
    public bool CanTransitionEnterPlatform()
    {
        return HasEnteredPlatform;
    }

    private void OnPreTutorialEnterPlatformEvent(object _, PreTutorialEnterPlatformEvent @event)
    {
        HasEnteredPlatform = true;
    }
}