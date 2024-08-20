public class BossPhaseState : IState
{
    private GameManager _gameManager;

    public int Phase = 1;

    public BossPhaseState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Tick()
    {
    }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.SoundFinishedEventHandler += OnSoundFinishedEvent;
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_1_INTRO);
        
        // TODO: Run beginning logic to spawn in boss
        ScaleGame.Instance.DelayedDelegate(30, NextPhase);
    }

    public void OnExit()
    {
        ResetState();
        ScaleGame.Instance.EventRegister.SoundFinishedEventHandler -= OnSoundFinishedEvent;
        StopAllSounds();
    }

    private void StopAllSounds()
    {
        new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_1_INTRO).Invoke();
        new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_1_LOOP).Invoke();
        new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_2_INTRO).Invoke();
        new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_2_LOOP).Invoke();
        new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_3_INTRO).Invoke();
        new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_3_LOOP).Invoke();
    }

    public void NextPhase()
    {
        switch (Phase)
        {
            case 1:
                new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_1_LOOP).Invoke();
                ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_2_INTRO);
                
                // TODO: Run logic to spawn in phase 2 boss
                ScaleGame.Instance.DelayedDelegate(30, NextPhase);
                break;
            case 2:
                new StopSoundEvent(Sounds.MUSIC_BOSS_PHASE_2_LOOP).Invoke();
                ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_3_INTRO);
                
                // TODO: Run logic to spawn in phase 3 boss
                ScaleGame.Instance.DelayedDelegate(30, NextPhase);
                break;
            case 3:
                // Winning logic
                _gameManager.IsVictory = true;
                _gameManager.IsGameOver = true;
                break;
        }
        Phase++;
    }

    public void ResetState()
    {
        Phase = 1;
    }
    
    private void OnSoundFinishedEvent(object _, SoundFinishedEvent @event)
    {
        if (@event.Sound == Sounds.MUSIC_BOSS_PHASE_1_INTRO)
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_1_LOOP);
        }

        if (@event.Sound == Sounds.MUSIC_BOSS_PHASE_2_INTRO)
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_2_LOOP);
        }
        
        if (@event.Sound == Sounds.MUSIC_BOSS_PHASE_3_INTRO)
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_3_LOOP);
        }
    }
}