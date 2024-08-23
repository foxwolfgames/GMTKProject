using UnityEngine;

public class ScaleDetectionZoneEnterEvent : IEvent
{
    public Collider Collider;
    public PlatformScaleSideSO SideData;

    public ScaleDetectionZoneEnterEvent(Collider collider, PlatformScaleSideSO sideData)
    {
        Collider = collider;
        SideData = sideData;
    }

    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeScaleDetectionZoneEnterEvent(this);
    }
}