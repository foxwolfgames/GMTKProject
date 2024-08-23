using FWGameLib.Common.StateMachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : IState
{
    private bool _hasPressedPlay = false;

    public void Tick()
    {
    }

    public void OnEnter()
    {
        ResetMenuState();
        ScaleGame.Instance.EventRegister.PressPlayEventHandler += OnPressPlayEvent;
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_TITLE);
    }

    public void OnExit()
    {
        Debug.Log("MenuState OnExit");
        ScaleGame.Instance.EventRegister.PressPlayEventHandler -= OnPressPlayEvent;
        new StopSoundEvent(Sounds.MUSIC_TITLE).Invoke();
        ResetMenuState();
    }

    private void ResetMenuState()
    {
        _hasPressedPlay = false;
    }

    private void OnPressPlayEvent(object _, PressPlayEvent @event)
    {
        _hasPressedPlay = true;
    }

    public bool CanTransitionPressPlay()
    {
        return _hasPressedPlay;
    }
}