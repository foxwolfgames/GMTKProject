using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement movementScript;
    public PlayerCamera cameraScript;

    InputActions controls;
    InputActions.PlayerMovementActions playerMovement;

    private Vector2 horizontalInput;
    private Vector2 cameraInput;
    private bool jumpInput;

    private void Awake()
    {
        controls = new InputActions();
        playerMovement = controls.PlayerMovement;

        // playerMovement.[action].performed += context => do something
        playerMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerMovement.CameraMovementX.performed += ctx => cameraInput.x = ctx.ReadValue<float>();
        playerMovement.CameraMovementY.performed += ctx => cameraInput.y = ctx.ReadValue<float>();
        playerMovement.Jump.performed += ctx => jumpInput = true;
        playerMovement.Jump.canceled += ctx => jumpInput = false;
    }

    private void Update()
    {
        movementScript.ReceiveMovementInput(horizontalInput);
        cameraScript.ReceiveInput(cameraInput);
        movementScript.ReceiveJumpInput(jumpInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDestroy()
    {
        controls.Disable();
    }
}
