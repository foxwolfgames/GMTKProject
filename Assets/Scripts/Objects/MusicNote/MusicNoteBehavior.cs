using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("MusicNote"))
        {
            Destroy(gameObject);
        }
    }
}
