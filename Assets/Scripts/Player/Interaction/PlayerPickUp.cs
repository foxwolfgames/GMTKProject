using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("References")] [SerializeField, Tooltip("Layer of pick-up-able item")]
    private LayerMask traceMask;

    [SerializeField, Tooltip("Layer of what stops colliding with object when picked up")]
    private LayerMask playerLayerMask;

    [SerializeField, Range(0, 31),
     Tooltip("Layer of player so that the player stops jumping on top of object when grabbing it")]
    private int playerLayer = 8;

    public Transform holdPoint;
    public Rigidbody targetRB = null;

    [SerializeField] private bool triedGrabbing = false;

    // Hold previous values
    private float rbAngularDrag = 0f;
    private int previousLayer;
    private LayerMask previousExclusionLayerMask;

    [Header("Hold Force")] public float rayTraceDistance = 3f;
    public float maxHoldForce = 10f;
    public float spring = 50f;
    public float damping = 5f;

    public float angularDrag = 2f;

    //public float distanceTolerance = 1f;
    [SerializeField] private ForceMode holdForceMode = ForceMode.Force;

    [Header("Throw Force")] public float throwForce = 10f;
    [SerializeField] private ForceMode throwForceMode = ForceMode.Impulse;

    [Header("Grab Cooldown")] public float grabCooldown = .25f;
    public bool isGrabOffCD = true;

    private void Update()
    {
        HoldingForces();
    }

    private void HoldingForces()
    {
        if (targetRB)
        {
            Vector3
                direction = holdPoint.position -
                            targetRB.gameObject.transform
                                .position; // Don't normalize, makes the force greater when object is further from holdPoint

            Vector3 springForce = direction * spring;
            Vector3 dampingForce = targetRB.velocity * damping;
            Vector3 force = springForce - dampingForce;

            force = Vector3.ClampMagnitude(force, maxHoldForce);

            targetRB.AddForce(force, holdForceMode);
        }
    }

    public void TryGrabObject()
    {
        if (!targetRB && !triedGrabbing && isGrabOffCD)
        {
            if (Physics.SphereCast(transform.position, 1f, transform.forward, out RaycastHit hit, rayTraceDistance,
                    traceMask))
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

        triedGrabbing = true;
    }

    public void ReleaseObject()
    {
        triedGrabbing = false;
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

    public void ThrowObject()
    {
        if (targetRB)
        {
            Vector3 direction = (holdPoint.position - transform.position).normalized;
            targetRB.AddForce(direction * throwForce, throwForceMode);

            ReleaseObject();
        }
    }

    private void ResetGrabCooldown()
    {
        isGrabOffCD = true;
    }

    private void SetLayersRecursion(GameObject _object, int layerToSet)
    {
        _object.layer = layerToSet;
        foreach (Transform childObject in _object.transform)
        {
            SetLayersRecursion(childObject.gameObject, layerToSet);
        }
    }
}