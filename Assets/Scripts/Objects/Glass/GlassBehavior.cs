using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehavior : MonoBehaviour
{
    private void OnEnable()
    {
        ScaleGame.Instance.RegisterGlassObject(this);
    }

    private void OnDisable()
    {
        ScaleGame.Instance.UnregisterGlassObject(this);
    }
    public void OnShatter(Vector3 shatterOrigin, float shatterRadius)
    {

        if (Vector3.Distance(transform.position, shatterOrigin) <= shatterRadius)
        {
            print("Destroying");
            Destroy(gameObject);
        }
    }
}
