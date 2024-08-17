using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbacusScript : MonoBehaviour
{
    public Rigidbody abacusRigidBody;
    public GameObject abacus;
    public float moveSpeed = 5;

    // Start is called before the first frame update
    void Start() 
    {
        
        transform.position = new Vector3(Random.Range(-22.0f, 22.0f), 30.0f, Random.Range(15.0f, -28.0f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
