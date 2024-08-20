using Unity.VisualScripting;
using UnityEngine;

public class MusicNoteBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private float time;
    public float frequency = .5f;
    public float torque = .2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rb)
        {
            time += Time.fixedDeltaTime;
            rb.AddTorque(Vector3.down * Mathf.Sin(time * frequency) * torque);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("MusicNote"))
        {
            gameObject.SetActive(false);
        }
    }
}
