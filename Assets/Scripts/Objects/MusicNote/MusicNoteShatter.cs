using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicNoteShatter : MonoBehaviour
{
    public float shatterRadius = 7f;
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a different tag
        if (!collision.gameObject.CompareTag("MusicNote"))
        {
            new NoteShatterEvent(transform.position, shatterRadius).Invoke();
            Destroy(gameObject);
        }
    }

    public void Test(Vector3 v, float f)
    {
        print("Shatter");
    }
}
