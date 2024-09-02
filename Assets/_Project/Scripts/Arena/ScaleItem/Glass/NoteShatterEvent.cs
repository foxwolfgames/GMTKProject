using FWGameLib.Common.EventSystem;
using UnityEngine;

public class NoteShatterEvent : IEvent
{
    public Vector3 Position;
    public float Radius;

    public NoteShatterEvent(Vector3 position, float radius)
    {
        Position = position;
        Radius = radius;
    }

    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeNoteShatterEvent(this);
    }
}