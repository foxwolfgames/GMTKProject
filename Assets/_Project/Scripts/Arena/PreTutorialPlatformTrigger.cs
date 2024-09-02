using UnityEngine;

public class PreTutorialPlatformTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            new PreTutorialEnterPlatformEvent().Invoke();
            gameObject.SetActive(false);
        }
    }
}