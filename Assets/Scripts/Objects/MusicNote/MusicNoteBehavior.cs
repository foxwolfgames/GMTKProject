using Unity.VisualScripting;
using UnityEngine;

public class MusicNoteBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("MusicNote"))
        {
            foreach (Transform childObject in gameObject.transform)
            {
                if(childObject.TryGetComponent<PooledAudioSource>(out PooledAudioSource _))
                {
                    childObject.transform.parent = null;
                }
            }
            gameObject.SetActive(false);
        }
    }
}