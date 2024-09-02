using FWGameLib.InProject.AudioSystem;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonHelper : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_BUTTON_CLICK);
    }
}