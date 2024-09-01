using FWGameLib.Common.AudioSystem.Event;
using FWGameLib.Common.StateMachine;
using FWGameLib.InProject.AudioSystem;
using UnityEngine;

public class BossPhaseState : IState
{
    private GameManager _gameManager;

    public int Phase = 1;
    private bool hasPlayedPhase1Loop = false;
    private float _timeElapsed = 0f;

    public BossPhaseState(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    public void Tick()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed > 8f && !hasPlayedPhase1Loop)
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_1_LOOP);
            hasPlayedPhase1Loop = true;
        }
    }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.FWGLSoundFinishedEventHandler += OnSoundFinishedEvent;
        ScaleGame.Instance.EventRegister.BossAdvanceEventHandler += OnBossAdvanceEvent;
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_1_INTRO);
        
        // TODO: Run beginning logic to spawn in boss (PHASE 1)
        // (right here coco)
        _gameManager.ArenaOrchestrator.boss.SetActive(true);
        
        // TODO: REMOVE THIS LINE!!! (this auto transitions)
        ScaleGame.Instance.DelayedDelegate(40, NextPhase);
    }

    public void OnExit()
    {
        ResetState();
        ScaleGame.Instance.EventRegister.FWGLSoundFinishedEventHandler -= OnSoundFinishedEvent;
        ScaleGame.Instance.EventRegister.BossAdvanceEventHandler -= OnBossAdvanceEvent;
        StopAllSounds();
    }

    private void StopAllSounds()
    {
        new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_1_INTRO).Invoke();
        new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_1_LOOP).Invoke();
        new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_2_INTRO).Invoke();
        new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_2_LOOP).Invoke();
        new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_3_INTRO).Invoke();
        new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_3_LOOP).Invoke();
    }

    // Call this method when you either
    // 1) defeat a phase of the boss
    // 2) defeat the boss in general
    public void NextPhase()
    {
        switch (Phase)
        {
            case 1:
                new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_1_LOOP).Invoke();
                ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_2_INTRO);
                break;
            case 2:
                new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_2_LOOP).Invoke();
                ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_3_INTRO);
                break;
            case 3:
                // Clean up the boss here (you win!!!)
                
                new FWGLStopSoundEvent(Sounds.MUSIC_BOSS_PHASE_3_LOOP).Invoke();
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
        hasPlayedPhase1Loop = false;
        _timeElapsed = 0f;
    }
    
    private void OnSoundFinishedEvent(object _, FWGLSoundFinishedEvent @event)
    {
        if (@event.Sound == Sounds.MUSIC_BOSS_PHASE_2_INTRO)
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_2_LOOP);
        }
        
        if (@event.Sound == Sounds.MUSIC_BOSS_PHASE_3_INTRO)
        {
            ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_BOSS_PHASE_3_LOOP);
        }
    }
    
    private void OnBossAdvanceEvent(object _, BossAdvanceEvent @event)
    {
        NextPhase();
    }
}