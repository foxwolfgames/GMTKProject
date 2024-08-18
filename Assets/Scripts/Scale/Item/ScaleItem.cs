using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ScaleItem : MonoBehaviour
{
    [Tooltip("Current mass, can be influenced by grow/shrink.")]
    public float mass;
    public ScaleItemSO type;
    public GameObject objectTransform;

    public Rigidbody rb;

    void Start()
    {
        mass = type.baseMass;
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }
}