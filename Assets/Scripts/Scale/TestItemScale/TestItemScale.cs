using System.Collections.Generic;
using UnityEngine;

public class TestItemScale : MonoBehaviour
{
    [ButtonInvoke("TestItemScalePrintDebug", customLabel: "Print console debug")] public bool buttonInvokePrintDebug;
    public LayerMask scaleItemMask;
    private readonly HashSet<Collider> _insideObjects = new();

    void Start()
    {
        InvokeUpdateEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer + " " + other.gameObject.name);
        if (!other.gameObject.IsInLayerMask(scaleItemMask))
        {
            return;
        }
        
        _insideObjects.Add(other);
        InvokeUpdateEvent();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.IsInLayerMask(scaleItemMask))
        {
            return;
        }
        
        _insideObjects.Remove(other);
        InvokeUpdateEvent();
    }

    private float GetTotalMassOfItems()
    {
        float totalMass = 0f;
        foreach (var insideCollider in _insideObjects)
        {
            if (insideCollider.attachedRigidbody.gameObject.TryGetComponent<ScaleItem>(out ScaleItem item))
            {
                totalMass += item.mass;
            }
        }

        return totalMass;
    }

    private void InvokeUpdateEvent()
    {
        new TestItemScaleBoardUpdateEvent(_insideObjects.Count, GetTotalMassOfItems()).Invoke();
    }

    private void TestItemScalePrintDebug()
    {
        Debug.Log("Items inside scale: " + _insideObjects.Count);
    }
}