using System.Collections.Generic;
using UnityEngine;

public class PlatformScaleSide : MonoBehaviour
{
    public PlatformScaleSideSO type;
    private readonly HashSet<GameObject> _insideObjects = new();
    public int NumItems => _insideObjects.Count;
    public float totalMass;

    void Start()
    {
        ScaleGame.Instance.EventRegister.ScaleDetectionZoneEnterEventHandler += OnScaleDetectionZoneEnterEvent;
        ScaleGame.Instance.EventRegister.ScaleDetectionZoneExitEventHandler += OnScaleDetectionZoneExitEvent;
    }

    private void OnScaleDetectionZoneEnterEvent(object _, ScaleDetectionZoneEnterEvent @event)
    {
        if (@event.SideData != type)
        {
            return;
        }

        GameObject obj = @event.Collider.attachedRigidbody.gameObject;
        if (obj.TryGetComponent<ScaleItem>(out ScaleItem item))
        {
            // Check if item is already inside
            if (!_insideObjects.Add(obj))
            {
                return;
            }

            totalMass += item.mass;
        }
    }

    private void OnScaleDetectionZoneExitEvent(object _, ScaleDetectionZoneExitEvent @event)
    {
        if (@event.SideData != type)
        {
            return;
        }

        GameObject obj = @event.Collider.attachedRigidbody.gameObject;
        if (obj.TryGetComponent<ScaleItem>(out ScaleItem item))
        {
            // Check if item is actually inside
            if (!_insideObjects.Remove(obj))
            {
                return;
            }

            totalMass -= item.mass;
        }
    }

    private void OnDisable()
    {
        ScaleGame.Instance.EventRegister.ScaleDetectionZoneEnterEventHandler -= OnScaleDetectionZoneEnterEvent;
        ScaleGame.Instance.EventRegister.ScaleDetectionZoneExitEventHandler -= OnScaleDetectionZoneExitEvent;
    }
}