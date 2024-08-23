using FWGameLib.Common.AudioSystem.Event;
using FWGameLib.InProject.AudioSystem;
using UnityEngine;

public class ArenaBridge : MonoBehaviour
{
    private const float LoweringTime = 8.0f;
    public Vector3 EndDelta = Vector3.down * 40.0f;
    public bool IsLowering = false;
    public bool IsLowered = false;
    private float _lowerTimer = 0.0f;
    public GameObject BridgeAnchor;

    void Update()
    {
        if (IsLowering)
        {
            _lowerTimer += Time.deltaTime;
            BridgeAnchor.transform.localPosition = Vector3.Lerp(Vector3.zero, EndDelta, EaseInCubic(_lowerTimer / LoweringTime));
            if (_lowerTimer >= LoweringTime)
            {
                IsLowering = false;
                IsLowered = true;
                new StopSoundEvent(Sounds.SFX_ARENA_BRIDGE_LOWERING).Invoke();
                BridgeAnchor.transform.localPosition -= Vector3.down * 1000f;
                new ArenaBridgeLoweringCompletedEvent(this).Invoke();
            }
        }
    }

    private float EaseInCubic(float t)
    {
        return t * t * t;
    }

    public void LowerBridge()
    {
        if (IsLowered || IsLowering) return;
        IsLowering = true;
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_ARENA_BRIDGE_LOWERING, BridgeAnchor.transform);
    }

    public void ResetState()
    {
        IsLowered = false;
        IsLowering = false;
        _lowerTimer = 0.0f;
        BridgeAnchor.transform.localPosition = Vector3.zero;
    }
}