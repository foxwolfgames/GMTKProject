using UnityEngine;

public class ScaleGame : MonoBehaviour
{
    public readonly EventRegister EventRegister = new();
    
    public static ScaleGame Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Destroy any other instances of this
            Destroy(gameObject);
        }
    }
}