using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScaleItemSO : ScriptableObject
{
    [Tooltip("Name of the object")]
    public string itemName;
    
    [Tooltip("Mass on the scale")]
    public float baseMass;
}
