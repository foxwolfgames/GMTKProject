using System;
using UnityEngine;

public class TutorialRedButton : MonoBehaviour
{
    public bool IsCaseOpen => _openPercentage >= 0.95f;
    public bool IsButtonPressed => _isButtonPressed;
    public GameObject CaseLidAnchor;
    public GameObject RedButtonAnchor;
    public Light PointLight;

    private const float CaseLidOpenAngle = -105f;
    
    private const float PercentagePerSecond = 0.5f;
    private bool _goalOpenState = false;
    private float _openPercentage = 0f;
    private bool _isButtonPressed;

    void Start()
    {
        ScaleGame.Instance.EventRegister.AttemptPressRedButtonEventHandler += OnAttemptPressRedButtonEvent;
    }
    
    // Open when player gets in proximity
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _goalOpenState = true;
        }
    }
    
    // Close when player leaves proximity
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _goalOpenState = false;
        }
    }

    void Update()
    {
        if (_goalOpenState)
        {
            _openPercentage += PercentagePerSecond * Time.deltaTime;
        }
        else
        {
            _openPercentage -= PercentagePerSecond * Time.deltaTime;
        }

        _openPercentage = Mathf.Clamp(_openPercentage, 0f, 1f);
        CaseLidAnchor.transform.localRotation = Quaternion.Euler(CaseLidOpenAngle * _openPercentage, 0f, 0f);
        PointLight.intensity = Mathf.Pow(_openPercentage, 3);
    }

    public bool Press()
    {
        if (!IsCaseOpen || _isButtonPressed) return false;
        _isButtonPressed = true;
        RedButtonAnchor.transform.localPosition += new Vector3(0f, -0.01f, 0f);
        new TutorialRedButtonPressedEvent().Invoke();
        return true;
    }
    
    private void OnAttemptPressRedButtonEvent(object _, AttemptPressRedButtonEvent @event)
    {
        if (_goalOpenState)
        {
            Press();
        }
    }
}