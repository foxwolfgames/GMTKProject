using UnityEngine;

public class UIButtonHelper : MonoBehaviour
{
    public void OnButtonClick()
    {
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_BUTTON_CLICK);
    }

    public void OnButtonHover()
    {
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_BUTTON_HOVER);
    }
}