using System.Collections.Generic;
using UnityEngine;

public class TestItemScale : MonoBehaviour
{
    public LayerMask scaleItemMask;
    private readonly HashSet<Collider> _insideObjects = new();
    
    void Update()
    {
        Debug.Log("Objects inside scale: " + _insideObjects.Count + " (" + name + ")");   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != scaleItemMask)
        {
            return;
        }
        
        _insideObjects.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != scaleItemMask)
        {
            return;
        }
        
        _insideObjects.Remove(other);
    }
}