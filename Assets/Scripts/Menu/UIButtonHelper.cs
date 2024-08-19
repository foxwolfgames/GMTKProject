using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHelper : MonoBehaviour, ISelectHandler
{
    public void OnSelect(BaseEventData eventData)
    {
        if (eventData.selectedObject != gameObject) return;
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_BUTTON_CLICK);
    }

    // TODO: sound on hover?
}