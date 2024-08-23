using System;
using UnityEngine;

public class ArenaKillzone : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            new FallIntoVoidEvent().Invoke();
        }
    }
}