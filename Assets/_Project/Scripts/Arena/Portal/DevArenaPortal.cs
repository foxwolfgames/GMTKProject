using UnityEngine;

public class DevArenaPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.attachedRigidbody.name);
        if (other.attachedRigidbody.name.Contains("Player"))
        {
            new DevEnterArenaEvent().Invoke();
        }
    }
}
