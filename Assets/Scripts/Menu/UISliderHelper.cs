using UnityEngine;

public class UISliderHelper : MonoBehaviour
{
    private void OnMouseDown()
    {
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_SLIDER_CHANGED);
    }
}