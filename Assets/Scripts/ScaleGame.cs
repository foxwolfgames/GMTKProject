using UnityEngine;

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
}