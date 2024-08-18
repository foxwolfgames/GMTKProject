using UnityEngine;

public class ScaleItem : MonoBehaviour
{
    [Tooltip("Current mass, can be influenced by grow/shrink.")]
    public float mass;
    public ScaleItemSO type;

    public Rigidbody _rb;

    void Start()
    {
        mass = type.baseMass;
        _rb = GetComponent<Rigidbody>();
        _rb.mass = mass;
    }
}