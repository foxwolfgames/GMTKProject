using UnityEngine;

public class ArenaPlatform : MonoBehaviour
{
    // Set in editor
    public Rigidbody platformRigidbody;
    public Transform redButtonInactivePosition;
    public Transform redButtonSkipTutorialPosition;
    public Transform redButtonEndTutorialPosition;
    public TutorialRedButton redButton;
    [Header("Guide Corners")]
    public Transform cornerPosXPosZ;
    public Transform cornerPosXNegZ;
    public Transform cornerNegXNegZ;
    public Transform cornerNegXPosZ;

    private RigidbodyConstraints CanRotateConstraints => RigidbodyConstraints.FreezePosition |
                                                         RigidbodyConstraints.FreezeRotationX |
                                                         RigidbodyConstraints.FreezeRotationY;

    void Update()
    {
        // Debug render bounding box of platform
        Debug.DrawLine(cornerPosXPosZ.position, cornerPosXNegZ.position, Color.green);
        Debug.DrawLine(cornerPosXNegZ.position, cornerNegXNegZ.position, Color.green);
        Debug.DrawLine(cornerNegXNegZ.position, cornerNegXPosZ.position, Color.green);
        Debug.DrawLine(cornerNegXPosZ.position, cornerPosXPosZ.position, Color.green);
        Debug.DrawLine(cornerPosXPosZ.position, cornerNegXNegZ.position, Color.green);
        Debug.DrawLine(cornerPosXNegZ.position, cornerNegXPosZ.position, Color.green);
        
        // Draw above but set y component of vector to 10
        float yLevel = 10f;
        Debug.DrawLine(new Vector3(cornerPosXPosZ.position.x, yLevel, cornerPosXPosZ.position.z), new Vector3(cornerPosXNegZ.position.x, yLevel, cornerPosXNegZ.position.z), Color.green);
        Debug.DrawLine(new Vector3(cornerPosXNegZ.position.x, yLevel, cornerPosXNegZ.position.z), new Vector3(cornerNegXNegZ.position.x, yLevel, cornerNegXNegZ.position.z), Color.green);
        Debug.DrawLine(new Vector3(cornerNegXNegZ.position.x, yLevel, cornerNegXNegZ.position.z), new Vector3(cornerNegXPosZ.position.x, yLevel, cornerNegXPosZ.position.z), Color.green);
        Debug.DrawLine(new Vector3(cornerNegXPosZ.position.x, yLevel, cornerNegXPosZ.position.z), new Vector3(cornerPosXPosZ.position.x, yLevel, cornerPosXPosZ.position.z), Color.green);
        Debug.DrawLine(new Vector3(cornerPosXPosZ.position.x, yLevel, cornerPosXPosZ.position.z), new Vector3(cornerNegXNegZ.position.x, yLevel, cornerNegXNegZ.position.z), Color.green);
        Debug.DrawLine(new Vector3(cornerPosXNegZ.position.x, yLevel, cornerPosXNegZ.position.z), new Vector3(cornerNegXPosZ.position.x, yLevel, cornerNegXPosZ.position.z), Color.green);
    }
    
    public void SetPlatformCanRotate(bool canRotate)
    {
        platformRigidbody.constraints = canRotate ? CanRotateConstraints : RigidbodyConstraints.FreezeAll;
    }
    
    public void SetRedButtonPosition(RedButtonPositions position)
    {
        switch (position)
        {
            case RedButtonPositions.INACTIVE:
                redButton.transform.parent = redButtonInactivePosition;
                redButton.transform.localPosition = Vector3.zero;
                break;
            case RedButtonPositions.SKIP_TUTORIAL:
                redButton.transform.parent = redButtonSkipTutorialPosition;
                redButton.transform.localPosition = Vector3.zero;
                break;
            case RedButtonPositions.END_TUTORIAL:
                redButton.transform.parent = redButtonEndTutorialPosition;
                redButton.transform.localPosition = Vector3.zero;
                break;
        }
    }
    
    public Bounds GetPlatformBoundsWithCorners()
    {
        Vector3 cornerPosXPosZWorld = cornerPosXPosZ.TransformPoint(cornerPosXPosZ.localPosition);
        Vector3 cornerPosXNegZWorld = cornerPosXNegZ.TransformPoint(cornerPosXNegZ.localPosition);
        Vector3 cornerNegXNegZWorld = cornerNegXNegZ.TransformPoint(cornerNegXNegZ.localPosition);
        Vector3 cornerNegXPosZWorld = cornerNegXPosZ.TransformPoint(cornerNegXPosZ.localPosition);
        
        Vector3 min = new Vector3(
            Mathf.Min(cornerPosXPosZWorld.x, cornerPosXNegZWorld.x, cornerNegXNegZWorld.x, cornerNegXPosZWorld.x),
            Mathf.Min(cornerPosXPosZWorld.y, cornerPosXNegZWorld.y, cornerNegXNegZWorld.y, cornerNegXPosZWorld.y),
            Mathf.Min(cornerPosXPosZWorld.z, cornerPosXNegZWorld.z, cornerNegXNegZWorld.z, cornerNegXPosZWorld.z)
        );
        
        Vector3 max = new Vector3(
            Mathf.Max(cornerPosXPosZWorld.x, cornerPosXNegZWorld.x, cornerNegXNegZWorld.x, cornerNegXPosZWorld.x),
            Mathf.Max(cornerPosXPosZWorld.y, cornerPosXNegZWorld.y, cornerNegXNegZWorld.y, cornerNegXPosZWorld.y),
            Mathf.Max(cornerPosXPosZWorld.z, cornerPosXNegZWorld.z, cornerNegXNegZWorld.z, cornerNegXPosZWorld.z)
        );

        return new Bounds((min + max) / 2, max - min);
    }
}

public enum RedButtonPositions
{
    INACTIVE,
    SKIP_TUTORIAL,
    END_TUTORIAL
}