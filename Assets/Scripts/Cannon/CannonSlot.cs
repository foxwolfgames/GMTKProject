using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CannonSlot : MonoBehaviour
{
    [SerializeField]
    private Collider launchObject;

    [SerializeField, Range(0, 31)]
    public int objectLayer = 10;
    public string playerTag = "Player";
    public Transform firePoint;
    [SerializeField] private float fireForce = 100f;
    [SerializeField] private ForceMode forceMode = ForceMode.VelocityChange;
    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            if (!launchObject && other.gameObject.tag != playerTag)
            {
                launchObject = other;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == launchObject)
        {
            launchObject = null;
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
        launchObject.attachedRigidbody.drag = 0;
        Vector3 direction = (firePoint.position - transform.position).normalized;
        launchObject.attachedRigidbody.AddForce(direction * fireForce, forceMode);

        launchObject = null;
    }
}
