using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformScaleSide : MonoBehaviour
{
    public PlatformScaleSideSO type;
    private readonly HashSet<GameObject> _insideObjects = new();
}