using TMPro;
using UnityEngine;

public class TestItemScaleBoard : MonoBehaviour
{
    private TextMeshPro _textMesh;

    void Start()
    {
        if (_textMesh == null)
        {
            _textMesh = GetComponent<TextMeshPro>();
        }
        ScaleGame.Instance.EventRegister.TestItemScaleBoardUpdateEventHandler += OnUpdateEvent;
    }

    private void UpdateBoard(int numItems, float totalMass)
    {
        _textMesh.text = "Mass: " + totalMass.ToString("0.0") + "kg";
    }

    private void OnUpdateEvent(object _, TestItemScaleBoardUpdateEvent @event)
    {
        UpdateBoard(@event.NumItems, @event.TotalMass);
    }

    private void OnDisable()
    {
        ScaleGame.Instance.EventRegister.TestItemScaleBoardUpdateEventHandler -= OnUpdateEvent;
    }
}