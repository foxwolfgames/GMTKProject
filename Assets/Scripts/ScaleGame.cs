using UnityEngine;
using UnityEngine.Events;

public class ScaleGame : MonoBehaviour
{
    public const string GrabbableObjectTag = "GrabbableObject";
    
    public readonly EventRegister EventRegister = new();
    
    public static ScaleGame Instance;

    public UnityEvent<Vector3, float> shatterEvent = new UnityEvent<Vector3, float>();


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

    public void RegisterGlassObject(GlassBehavior glassBehavior)
    {
        shatterEvent.AddListener(glassBehavior.OnShatter);
    }

    public void UnregisterGlassObject(GlassBehavior glassBehavior)
    {
        shatterEvent.RemoveListener(glassBehavior.OnShatter);
    }

    public void NotifyGlassObject(Vector3 originLocation, float originRadius)
    {
        shatterEvent.Invoke(originLocation, originRadius);
    }
}