public class MenuState : IState
{
    private bool _hasPressedPlay = false;
    
    public void Tick() { }

    public void OnEnter()
    {
        ScaleGame.Instance.EventRegister.PressPlayEventHandler += OnPressPlayEvent;
        ResetMenuState();
    }

    public void OnExit()
    {
        ScaleGame.Instance.EventRegister.PressPlayEventHandler -= OnPressPlayEvent;
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