using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private List<PanelInfo> panelList = new List<PanelInfo>();

    // if we need to go to a different scene once dialogue is finished
    // [SerializeField]
    // private string gameplaySceneName = string.Empty;

    private int currentPanel = -1;
    private Coroutine coroutine;

    private void OnValidate()
    {
        if (canvas == null)
        {
            Debug.LogWarning("Canvas is not assigned in DialogueContainer");
            return;
        }
        if (panelList.Count < canvas.transform.childCount)
        {
            List<GameObject> panels = new List<GameObject>();
            for (int c = 0; c < canvas.transform.childCount; c++)
            {
                GameObject panel = canvas.transform.GetChild(c).gameObject;
                if (panel.name.IndexOf("Panel", System.StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    panels.Add(panel);
                }
            }

            for (int p = panelList.Count; p < panels.Count; p++)
            {
                panelList.Add(new PanelInfo() { panel = panels[p] });
            }
        }
    }

    // event listeners for inputs for pause/skip
    // private void Update()
    // {
    //     if (currentPanel < 0 || currentPanel >= panelList.Count)
    //         // || Time.timeScale == 0f)
    //     {
    //         return;
    //     }

    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         AdvancePanel();
    //     }
    //     else if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         TogglePause();
    //     }    
    // }

    public void PlayNarrative()
    {
        canvas.gameObject.SetActive(true);
        for (int c = 0; c < canvas.transform.childCount; c++)
        {
            canvas.transform.GetChild(c).gameObject.SetActive(false);
        }
        TransitionPanel();
    }

    public void HideNarrative()
    {
        canvas.gameObject.SetActive(false);
    }

    public void SkipNarrative()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        TogglePause();
        // SceneManager.LoadScene(gameplaySceneName);
    }

    public void TogglePause()
    {
        bool alreadyPaused = Time.timeScale == 0f;
        Time.timeScale = alreadyPaused ? 1f : 0f;
        pauseMenu.SetActive(!alreadyPaused);
    }

    private void TransitionPanel()
    {
        if(currentPanel >= 0 && currentPanel < panelList.Count - 1)
        {
            panelList[currentPanel].panel.SetActive(false);
        }
        currentPanel++;
        if (currentPanel < panelList.Count)
        {
            panelList[currentPanel].panel.SetActive(true);
            // coroutine = StartCoroutine(TransitionPanelCoroutine());
        }
        else
        {
            canvas.gameObject.SetActive(false);
            // SceneManager.LoadScene(gameplaySceneName);
        }
    }

    public void AdvancePanel()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        TransitionPanel();
        Debug.Log("Advance Panel");
    }

    // if we want dialogue to automatically advance after x seconds
    // private IEnumerator TransitionPanelCoroutine()
    // {
    //     yield return new WaitForSeconds(panelList[currentPanel].displayDuration);
    //     TransitionPanel();
    // }

    [System.Serializable]
    private class PanelInfo
    {
        public GameObject panel;
        // for automatically advancing dialogue after x seconds along with IEnumerator ()
        // public float displayDuration = 10f;
    }
}
