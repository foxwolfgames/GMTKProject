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

    private void Awake()
    {
        controls = new InputActions();
        playerMovement = controls.PlayerMovement;
        playerInteraction = controls.PlayerInteraction;

        // playerMovement.[action].performed += context => do something
        playerMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerMovement.CameraMovementX.performed += ctx => cameraInput.x = ctx.ReadValue<float>();
        playerMovement.CameraMovementY.performed += ctx => cameraInput.y = ctx.ReadValue<float>();
        playerMovement.Jump.performed += ctx => movementScript.ReceiveJumpInput(true);
        playerMovement.Jump.canceled += ctx => movementScript.ReceiveJumpInput(false);
        playerMovement.Sprint.performed += ctx => movementScript.ReceiveSprintInput(true);
        playerMovement.Sprint.canceled += ctx => movementScript.ReceiveSprintInput(false);

        playerInteraction.GrabAction.performed += ctx => pickupScript.TryGrabObject();
        playerInteraction.GrabAction.canceled += ctx => pickupScript.ReleaseObject();
        playerInteraction.ThrowAction.performed += ctx => pickupScript.ThrowObject();
    }

    private void Update()
    {
        movementScript.ReceiveMovementInput(horizontalInput);
        cameraScript.ReceiveInput(cameraInput);

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
