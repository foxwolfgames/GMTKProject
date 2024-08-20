using UnityEngine;

public class ArenaPlatform : MonoBehaviour
{
    // Set in editor
    public Rigidbody platformRigidbody;
    public Transform redButtonInactivePosition;
    public Transform redButtonSkipTutorialPosition;
    public Transform redButtonEndTutorialPosition;
    public TutorialRedButton redButton;

    private RigidbodyConstraints CanRotateConstraints => RigidbodyConstraints.FreezePosition |
                                                         RigidbodyConstraints.FreezeRotationX |
                                                         RigidbodyConstraints.FreezeRotationY;
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
}

public enum RedButtonPositions
{
    INACTIVE,
    SKIP_TUTORIAL,
    END_TUTORIAL
}