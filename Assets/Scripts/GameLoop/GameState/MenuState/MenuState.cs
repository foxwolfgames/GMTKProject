using UnityEngine;

public class MenuState : IState
{
    private bool _hasPressedPlay = false;

    public void Tick()
    {
    }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.PressPlayEventHandler += OnPressPlayEvent;
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_TITLE);
        ResetMenuState();
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