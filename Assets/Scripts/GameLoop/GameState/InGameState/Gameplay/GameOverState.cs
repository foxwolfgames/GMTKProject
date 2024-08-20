using UnityEngine;

public class GameOverState : IState
{
    private GameManager _gameManager;
    
    public GameOverState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }
    
    public void Tick()
    {
        
    }

    public void OnEnter()
    {
        _gameManager.ArenaOrchestrator.gameOverMenu.Show(_gameManager.IsVictory);
        // Disable controls
        new GameOverEvent().Invoke();
    }

    public void OnExit()
    {
        
    }
}