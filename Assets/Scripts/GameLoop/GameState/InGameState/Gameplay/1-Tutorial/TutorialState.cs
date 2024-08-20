public class TutorialState : IState
{
    private GameManager _gameManager;
    private bool BridgeLoweringCompleted = false;
    
    public TutorialState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Tick()
    {
        //throw new System.NotImplementedException();
    }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.ArenaBridgeLoweringCompletedEventHandler += OnBridgeLoweringCompletedEvent;
        _gameManager.ArenaOrchestrator.bridge.LowerBridge();
    }

    public void OnExit()
    {
        new StopSoundEvent(Sounds.MUSIC_GAME_TUTORIAL).Invoke();
        ScaleGame.Instance.EventRegister.ArenaBridgeLoweringCompletedEventHandler -= OnBridgeLoweringCompletedEvent;
    }

    public void ResetState()
    {
        BridgeLoweringCompleted = false;
    }
    
    private void OnBridgeLoweringCompletedEvent(object _, ArenaBridgeLoweringCompletedEvent @event)
    {
        BridgeLoweringCompleted = true;
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_GAME_TUTORIAL);
    }
}