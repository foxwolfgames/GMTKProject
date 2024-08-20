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
        Debug.Log("GAME OVER!");
        if (_gameManager.IsVictory)
        {
            Debug.Log("VICTORY!");
        }
        else
        {
            Debug.Log("DEFEAT!");
        }
    }

    public void OnExit()
    {
        
    }
}