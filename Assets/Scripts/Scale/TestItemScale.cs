using System.Collections.Generic;
using UnityEngine;

public class TestItemScale : MonoBehaviour
{
    [ButtonInvoke("TestItemScalePrintDebug", customLabel: "Print console debug")] public bool buttonInvokePrintDebug;
    public LayerMask scaleItemMask;
    private readonly HashSet<Collider> _insideObjects = new();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.layer + " " + other.gameObject.name);
        if (!other.gameObject.IsInLayerMask(scaleItemMask))
        {
            return;
        }
        
        _insideObjects.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.IsInLayerMask(scaleItemMask))
        {
            return;
        }
        
        _insideObjects.Remove(other);
    }

    private void TestItemScalePrintDebug()
    {
        Debug.Log("Items inside scale: " + _insideObjects.Count);
    }
}