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
    }
    
    
}