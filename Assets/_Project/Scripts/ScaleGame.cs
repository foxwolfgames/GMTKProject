using System.Collections;
using FWGameLib.Common.AudioSystem;
using FWGameLib.InProject.EventSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleGame : MonoBehaviour
{
    public EventRegister EventRegister { get; private set; }
    public ScaleGameLoop GameLoop { get; private set; }
    public AudioManager Audio { get; private set; }

    public static ScaleGame Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            EventRegister = new EventRegister();
            GameLoop = new ScaleGameLoop();
            Audio = GetComponent<AudioManager>();
            GameLoop.Awake();
        }
        else
        {
            // Destroy any other instances of this
            Destroy(gameObject);
        }
    }

    void Update()
    {
        GameLoop.Update();
    }
    
    public void LoadSceneAsyncAndStopAllAudioSources(Scenes scene)
    {
        StartCoroutine(LoadScene((int) scene));
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        yield return null;
        
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            Scene scene = SceneManager.GetActiveScene();
            foreach (GameObject obj in scene.GetRootGameObjects())
            {
                if (obj.TryGetComponent<PooledAudioSource>(out PooledAudioSource pas))
                {
                    pas.audioSource.Stop();
                }
            }

            asyncOperation.allowSceneActivation = true;
            yield return null;
        }
    }

    public void DelayedDelegate(int seconds, System.Action method)
    {
        StartCoroutine(DelayedDelegateCoroutine(seconds, method));
    }
    
    IEnumerator DelayedDelegateCoroutine(int seconds, System.Action method)
    {
        yield return new WaitForSeconds(seconds);
        method();
    }
}