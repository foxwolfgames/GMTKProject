using FWGameLib.Common.StateMachine;

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
        ScaleGame.Instance.EventRegister.GameStopEventHandler += OnGameStopEvent;
        ScaleGame.Instance.Audio.PlaySound(Sounds.VOICE_ANNOUNCER_ENTER_ARENA);
    }

    public void OnExit()
    {
        ResetState();
        ScaleGame.Instance.EventRegister.GameStopEventHandler -= OnGameStopEvent;
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
    
    private void OnGameStopEvent(object _, GameStopEvent @event)
    {
        new StopSoundEvent(Sounds.VOICE_ANNOUNCER_ENTER_ARENA).Invoke();
    }
}