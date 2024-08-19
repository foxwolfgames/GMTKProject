using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehavior : MonoBehaviour
{
    private void Start()
    {
        ScaleGame.Instance.EventRegister.NoteShatterEventHandler += OnNoteShatterEvent;
    }

    private void OnDisable()
    {
        ScaleGame.Instance.EventRegister.NoteShatterEventHandler -= OnNoteShatterEvent;
    }

    private void OnNoteShatterEvent(object _, NoteShatterEvent @event)
    {
        if (Vector3.Distance(transform.position, @event.Position) <= @event.Radius)
        {
            print("Destroying");
            Destroy(gameObject);
        }
    }
}
