using UnityEngine;

public class ArenaPlatform : MonoBehaviour
{
    // Set in editor
    public Rigidbody platformRigidbody;

    private RigidbodyConstraints CanRotateConstraints => RigidbodyConstraints.FreezePosition |
                                                         RigidbodyConstraints.FreezeRotationX |
                                                         RigidbodyConstraints.FreezeRotationY;
    public void SetPlatformCanRotate(bool canRotate)
    {
        platformRigidbody.constraints = canRotate ? CanRotateConstraints : RigidbodyConstraints.FreezeAll;
    }
}