using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPickUp : MonoBehaviour
{
    public float rayTraceDistance = 3f;
    public LayerMask traceMask; // Layer of pick-up-able item
    
    private bool isGrabbing = false;
    private float rbAngularDrag = 0f;
    [Header("References")]
    public LayerMask playerLayerMask; // Layer of what stops colliding with object when picked up
    private LayerMask previousExclusionLayerMask;
    [SerializeField, Range(0, 31)]
    public int playerLayer = 8; // Set layer to player so that the player stops jumping on top of object when grabbing it
    private int previousLayer;
    public Transform holdPoint;
    public Rigidbody targetRB = null;

    [Header("Force")]
    public float maxHoldForce = 10f;
    public float spring = 50f;
    public float damping = 5f;
    public float angularDrag = 2f;
    //public float distanceTolerance = 1f;

    [Header("Cooldown")]
    public float grabCooldown = .25f;
    public bool isGrabOffCD = true;
    public void ReceiveInput(bool grabInput)
    {
        isGrabbing = grabInput;
        if (isGrabbing && isGrabOffCD)
        {
            TryGrabObject();
        }
        else
        {
            ReleaseObject();
        }
    }
    private void Update()
    {
        if (targetRB)
        {
            Vector3 direction = holdPoint.position - targetRB.gameObject.transform.position;
            float distance = direction.magnitude;

            Vector3 springForce = direction * spring;
            Vector3 dampingForce = targetRB.velocity * damping;
            Vector3 force = springForce - dampingForce;

            force = Vector3.ClampMagnitude(force, maxHoldForce);

            targetRB.AddForce(force, ForceMode.Force);
        }
    }

    private void TryGrabObject()
    {
        if (!targetRB)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.SphereCast(transform.position, 1f, transform.forward, out RaycastHit hit, rayTraceDistance, traceMask))
            {
                targetRB = hit.collider.attachedRigidbody;

                // Save previous settings
                rbAngularDrag = targetRB.angularDrag;
                previousLayer = targetRB.gameObject.layer;
                previousExclusionLayerMask = targetRB.excludeLayers;

                // Change settings
                targetRB.angularDrag = angularDrag;
                SetLayersRecursion(targetRB.gameObject, playerLayer);
                targetRB.excludeLayers = playerLayerMask;
            }
        }
    }
    private void ReleaseObject()
    {
        if (targetRB)
        {
            // Restore previous settings
            targetRB.angularDrag = rbAngularDrag;
            SetLayersRecursion(targetRB.gameObject, previousLayer);
            targetRB.excludeLayers = previousExclusionLayerMask;

            rbAngularDrag = 0f;
            targetRB = null;

            isGrabOffCD = false;
            Invoke(nameof(ResetGrabCooldown), grabCooldown);
        }
    }

    private void ResetGrabCooldown()
    {
        isGrabOffCD = true;
    }

    private void SetLayersRecursion(GameObject _object, int layerToSet)
    {
        _object.layer = layerToSet;
        foreach(Transform childObject in _object.transform)
        {
            SetLayersRecursion(childObject.gameObject, layerToSet);
        }
    }
}
