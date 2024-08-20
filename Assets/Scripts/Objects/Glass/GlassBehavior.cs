using UnityEngine;

public class GlassBehavior : BossItemBehavior
{
    protected override void Start()
    {
        ScaleGame.Instance.EventRegister.NoteShatterEventHandler += OnNoteShatterEvent;
    }

    protected override void OnDisable()
    {
        ScaleGame.Instance.EventRegister.NoteShatterEventHandler -= OnNoteShatterEvent;
    }

    private void OnNoteShatterEvent(object _, NoteShatterEvent @event)
    {
        if (Vector3.Distance(transform.position, @event.Position) <= @event.Radius)
        {
            print("Destroying");
            spawnScript.RemoveItem(gameObject);
            gameObject.SetActive(false);
        }
    }
}