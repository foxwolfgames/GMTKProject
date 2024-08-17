using UnityEngine;

public class ScaleDetectionZone : MonoBehaviour
{
    [Tooltip("Data about the side this detection zone belongs to.")]
    public PlatformScaleSideSO sideData;
    
    private void OnTriggerEnter(Collider other)
    {
        new ScaleDetectionZoneEnterEvent(other, sideData).Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        new ScaleDetectionZoneExitEvent(other, sideData).Invoke();
    }
}