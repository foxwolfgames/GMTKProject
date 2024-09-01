using FWGameLib.Common.AudioSystem.Event;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static PauseMenu _instance;
    public Canvas canvas;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            canvas.enabled = false;   
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ScaleGame.Instance.EventRegister.PauseEventHandler += OnPauseEvent;
        ScaleGame.Instance.EventRegister.UnpauseEventHandler += OnUnpauseEvent;
        ScaleGame.Instance.EventRegister.QuitToMenuEventHandler += OnQuitToMenuEvent;
    }
    
    public void Unpause()
    {
        new UnpauseEvent().Invoke();
    }
    
    public void QuitToMenu()
    {
        new QuitToMenuEvent().Invoke();
    }
    
    public void OnPauseEvent(object _, PauseEvent @event)
    {
        new FWGLAudioPauseEvent().Invoke();
        canvas.enabled = true;
    }
    
    public void OnUnpauseEvent(object _, UnpauseEvent @event)
    {
        canvas.enabled = false;
        new FWGLAudioUnpauseEvent().Invoke();
    }
    
    public void OnQuitToMenuEvent(object _, QuitToMenuEvent @event)
    {
        canvas.enabled = false;
    }
}