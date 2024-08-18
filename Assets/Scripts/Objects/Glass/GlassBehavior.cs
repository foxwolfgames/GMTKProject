using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehavior : MonoBehaviour
{
    public void OnShatter(Vector3 shatterOrigin, float shatterRadius)
    {

        if (Vector3.Distance(transform.position, shatterOrigin) <= shatterRadius)
        {
            print("Destroying");
            Destroy(gameObject);
        }
    }
}
