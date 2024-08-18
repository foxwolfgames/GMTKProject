using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement movementScript;
    public PlayerCamera cameraScript;
    public PlayerPickUp pickupScript;

    InputActions controls;
    InputActions.PlayerMovementActions playerMovement;
    InputActions.PlayerInteractionActions playerInteraction;

    private Vector2 horizontalInput;
    private Vector2 cameraInput;
    private bool jumpInput;
    private bool grabInput;

    private void Awake()
    {
        controls = new InputActions();
        playerMovement = controls.PlayerMovement;
        playerInteraction = controls.PlayerInteraction;

        // playerMovement.[action].performed += context => do something
        playerMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerMovement.CameraMovementX.performed += ctx => cameraInput.x = ctx.ReadValue<float>();
        playerMovement.CameraMovementY.performed += ctx => cameraInput.y = ctx.ReadValue<float>();
        playerMovement.Jump.performed += ctx => jumpInput = true;
        playerMovement.Jump.canceled += ctx => jumpInput = false;

        playerInteraction.GrabAction.performed += ctx => grabInput = true;
        playerInteraction.GrabAction.canceled += ctx => grabInput = false;
    }

    private void Update()
    {
        movementScript.ReceiveMovementInput(horizontalInput);
        cameraScript.ReceiveInput(cameraInput);
        movementScript.ReceiveJumpInput(jumpInput);

        pickupScript.ReceiveInput(grabInput);
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