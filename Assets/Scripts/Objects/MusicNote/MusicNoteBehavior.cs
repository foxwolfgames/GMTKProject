using Unity.VisualScripting;
using UnityEngine;

public class MusicNoteBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("MusicNote"))
        {
            gameObject.SetActive(false);
        }
    }
}
