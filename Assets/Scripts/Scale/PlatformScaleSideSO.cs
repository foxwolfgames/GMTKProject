using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu]
public class PlatformScaleSideSO : ScriptableObject
{
    [Tooltip("ID of the side on the platform scale")]
    public int sideId;

    [Tooltip("The axis along which this side lies.")]
    public Axis sideAxis;
    
    [Tooltip("Whether this is on the positive or negative side of the axis.")]
    public bool isPositive;
}