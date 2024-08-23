using UnityEngine;

[CreateAssetMenu]
public class ScaleItemSO : ScriptableObject
{
    [Tooltip("Name of the object")] public string itemName;

    [Tooltip("Mass on the scale")] public float baseMass;

    [Tooltip("Whether this object is 'glass' meaning it can be broken by objects.")]
    public bool isGlass = false;
}