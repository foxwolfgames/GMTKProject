using FWGameLib.Common.AudioSystem;
using FWGameLib.Common.AudioSystem.Event;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIVolumeSlider : MonoBehaviour
{
    [FormerlySerializedAs("audioType")] public AudioVolumeType audioVolumeType;

    void Start()
    {
        Slider slider = GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = 1f;
        slider.onValueChanged.AddListener(OnValueChange);
    }

    private void OnEnable()
    {
        Slider slider = GetComponent<Slider>();
        slider.value = ScaleGame.Instance.Audio.VolumeValues[audioVolumeType];
    }

    private void OnValueChange(float newValue)
    {
        new ChangeVolumeEvent(audioVolumeType, newValue).Invoke();
    }
}