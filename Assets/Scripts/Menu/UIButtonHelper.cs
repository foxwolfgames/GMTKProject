using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonHelper : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.selectedObject != gameObject) return;
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_BUTTON_HOVER);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (eventData.selectedObject != gameObject) return;
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_BUTTON_CLICK);
    }
}