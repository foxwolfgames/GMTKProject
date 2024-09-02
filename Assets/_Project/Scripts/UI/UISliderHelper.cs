using FWGameLib.InProject.AudioSystem;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISliderHelper : MonoBehaviour, IInitializePotentialDragHandler
{
    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (eventData.selectedObject != gameObject) return;
        ScaleGame.Instance.Audio.PlaySound(Sounds.SFX_UI_SLIDER_CHANGED);
    }
}