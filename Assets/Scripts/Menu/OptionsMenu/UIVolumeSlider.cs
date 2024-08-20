using UnityEngine;
using UnityEngine.UI;

public class UIVolumeSlider : MonoBehaviour
{
    public AudioType audioType;

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
        slider.value = ScaleGame.Instance.Audio.VolumeValues[audioType];
    }

    private void OnValueChange(float newValue)
    {
        new ChangeVolumeEvent(audioType, newValue).Invoke();
    }
}