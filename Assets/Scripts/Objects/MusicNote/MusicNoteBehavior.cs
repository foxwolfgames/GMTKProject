using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteBehavior : MonoBehaviour
{
    public float gravityModifier = 0.2f;
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("MusicNote"))
        {
            Destroy(gameObject);
        }
    }
}
