using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaleGame : MonoBehaviour
{
    public readonly EventRegister EventRegister = new();
    public readonly ScaleGameLoop GameLoop = new();
    public AudioManager Audio;

    public static ScaleGame Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
}