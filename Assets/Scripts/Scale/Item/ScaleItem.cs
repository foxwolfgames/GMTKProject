using UnityEngine;

public class ScaleItem : MonoBehaviour
{
    public ScaleItemSO type;

    [Tooltip("Current mass, can be influenced by grow/shrink.")]
    public float mass;

    public Rigidbody rb;

    void Start()
    {
        mass = type.baseMass;
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
    }

    void Update()
    {
        if (transform.position.y < -100)
        {
            gameObject.SetActive(false);
        }
    }
}