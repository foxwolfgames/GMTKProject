using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSlot : MonoBehaviour
{
    private Collider launchObject;

    [SerializeField, Range(0, 31)]
    public int objectLayer = 10;
    public Transform firePoint;
    [SerializeField] private float fireForce = 100f;
    [SerializeField] private ForceMode forceMode = ForceMode.VelocityChange;
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            if (!launchObject)
            {
                launchObject = other;
            }
        }
    }

    private void Update()
    {
        if(launchObject)
            if (launchObject.gameObject.layer == objectLayer)
                Launch();
    }

    private void Launch()
    {
        launchObject.transform.position = transform.position;
        Vector3 direction = (firePoint.position - transform.position).normalized;
        launchObject.attachedRigidbody.AddForce(direction * fireForce, forceMode);

        launchObject = null;
    }
}
