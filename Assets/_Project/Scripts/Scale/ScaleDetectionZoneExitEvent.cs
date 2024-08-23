using FWGameLib.Common.EventSystem;
using UnityEngine;

public class ScaleDetectionZoneExitEvent : IEvent
{
    public Collider Collider;
    public PlatformScaleSideSO SideData;

    public ScaleDetectionZoneExitEvent(Collider collider, PlatformScaleSideSO sideData)
    {
        Collider = collider;
        SideData = sideData;
    }

    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeScaleDetectionZoneExitEvent(this);
    }
}