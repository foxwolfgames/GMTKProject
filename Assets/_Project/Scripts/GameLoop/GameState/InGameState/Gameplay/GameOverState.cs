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
        new StopSoundEvent(Sounds.SFX_AMBIENCE_ARENA_CROWD).Invoke();
        
        if (_gameManager.IsVictory)
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_VICTORY);
        }
        else
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_FAILURE);
        }
        
        _gameManager.ArenaOrchestrator.gameOverMenu.Show(_gameManager.IsVictory);
        // Disable controls
        new GameOverEvent().Invoke();
    }

    public void OnExit()
    {
        new StopSoundEvent(Sounds.MUSIC_VICTORY).Invoke();
        new StopSoundEvent(Sounds.SFX_FAILURE).Invoke();
    }
}