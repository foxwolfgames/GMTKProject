using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPickUp : MonoBehaviour
{
    public float rayTraceDistance = 3f;
    public LayerMask traceMask;
    
    private bool isGrabbing = false;
    private float rbAngularDrag = 0f;
    [Header("References")]
    public LayerMask playerLayerMask;
    private LayerMask previousLayerMask;
    public Transform holdPoint;
    public Rigidbody targetRB = null;

    [Header("Force")]
    public float maxHoldForce = 10f;
    public float spring = 50f;
    public float damping = 5f;
    public float angularDrag = 2f;
    public float distanceTolerance = 1f;

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
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, rayTraceDistance, traceMask))
            {
                Rigidbody rb = hit.collider.attachedRigidbody;
                if (rb.gameObject.CompareTag(ScaleGame.GrabbableObjectTag))
                {
                    targetRB = rb;

                    // Save previous settings
                    rbAngularDrag = targetRB.angularDrag;
                    previousLayerMask = targetRB.excludeLayers;

                    // Change settings
                    targetRB.angularDrag = angularDrag;
                    targetRB.excludeLayers = playerLayerMask;
                }
            }
        }
    }
    private void ReleaseObject()
    {
        if (targetRB)
        {
            // Restore previous settings
            targetRB.angularDrag = rbAngularDrag;
            targetRB.excludeLayers = previousLayerMask;

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
}
