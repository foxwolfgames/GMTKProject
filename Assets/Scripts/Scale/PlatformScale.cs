using UnityEngine;

public class PlatformScale : MonoBehaviour
{
    private PlatformScaleSide _posXSide;
    private PlatformScaleSide _negXSide;

    private void Awake()
    {
        _posXSide = new PlatformScaleSide();
        _negXSide = new PlatformScaleSide();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}