using System;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public Canvas canvas;
    private bool _didWin;
    public GameObject winText;
    public GameObject loseText;

    void Start()
    {
        canvas.enabled = false;
        ScaleGame.Instance.EventRegister.QuitToMenuEventHandler += OnQuitToMenuEvent;
    }

    public void Show(bool didWin)
    {
        canvas.enabled = true;
        _didWin = didWin;
    }

    void Update()
    {
        winText.SetActive(_didWin);
        loseText.SetActive(!_didWin);
    }

    private void OnDisable()
    {
        ScaleGame.Instance.EventRegister.QuitToMenuEventHandler -= OnQuitToMenuEvent;
    }

    public void QuitToMenu()
    {
        new QuitToMenuEvent().Invoke();
    }
    
    public void OnQuitToMenuEvent(object _, QuitToMenuEvent @event)
    {
        canvas.enabled = false;
        ScaleGame.Instance.LoadSceneAsyncAndStopAllAudioSources(Scenes.MAIN_MENU);
        new GameStopEvent().Invoke();
        Time.timeScale = 1f;
        InGameState.IsGameOverAndQuit = true;
    }
}