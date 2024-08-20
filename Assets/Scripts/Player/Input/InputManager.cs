using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerMovement movementScript;
    public PlayerCamera cameraScript;
    public PlayerPickUp pickupScript;

    InputActions controls;
    InputActions.PlayerMovementActions playerMovement;
    InputActions.PlayerInteractionActions playerInteraction;
    InputActions.CanPauseActionsActions canPauseActions;
    InputActions.InPauseMenuActionsActions inPauseMenuActions;

    private Vector2 horizontalInput;
    private Vector2 cameraInput;

    private void Awake()
    {
        controls = new InputActions();
        playerMovement = controls.PlayerMovement;
        playerInteraction = controls.PlayerInteraction;
        canPauseActions = controls.CanPauseActions;
        inPauseMenuActions = controls.InPauseMenuActions;

        // playerMovement.[action].performed += context => do something
        playerMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        playerMovement.CameraMovementX.performed += ctx => cameraInput.x = ctx.ReadValue<float>();
        playerMovement.CameraMovementY.performed += ctx => cameraInput.y = ctx.ReadValue<float>();
        playerMovement.Jump.performed += ctx => movementScript.ReceiveJumpInput(true);
        playerMovement.Jump.canceled += ctx => movementScript.ReceiveJumpInput(false);
        playerMovement.Sprint.performed += ctx => movementScript.ReceiveSprintInput(true);
        playerMovement.Sprint.canceled += ctx => movementScript.ReceiveSprintInput(false);

        playerInteraction.GrabAction.performed += ctx => pickupScript.TryGrabObject();
        playerInteraction.GrabAction.canceled += ctx => pickupScript.ReleaseObject(true);
        playerInteraction.ThrowAction.performed += ctx => pickupScript.ThrowObject();
        playerInteraction.PressRedButtonAction.performed += _ => new AttemptPressRedButtonEvent().Invoke();

        canPauseActions.PauseGame.performed += _ => new PauseEvent().Invoke();
        inPauseMenuActions.UnpauseGame.performed += _ => new UnpauseEvent().Invoke();
    }
    
    private void Start()
    {
        Debug.Log("InputManager (start)");
        // Assuming that this start is called after the player controller has been initialized
        
        SetupInGameControls();
        ScaleGame.Instance.EventRegister.PauseEventHandler += OnPauseEvent;
        ScaleGame.Instance.EventRegister.UnpauseEventHandler += OnUnpauseEvent;
        ScaleGame.Instance.EventRegister.GameStartEventHandler += OnGameStartEvent;
        ScaleGame.Instance.EventRegister.GameStopEventHandler += OnGameStopEvent;
    }

    private void SetupInGameControls()
    {
        playerMovement.Enable();
        playerInteraction.Enable();
        canPauseActions.Enable();
        inPauseMenuActions.Disable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void SetupPauseMenuControls()
    {
        playerMovement.Disable();
        playerInteraction.Disable();
        canPauseActions.Disable();
        inPauseMenuActions.Enable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        movementScript.ReceiveMovementInput(horizontalInput);
        cameraScript.ReceiveInput(cameraInput);
    }

    private void OnEnable()
    {
        Debug.Log("InputManager enabled (onEnable)");
        controls.Enable();
    }

    private void OnDestroy()
    {
        Debug.Log("InputManager disabled (destroyed)");
        controls.Disable();
        ScaleGame.Instance.EventRegister.PauseEventHandler -= OnPauseEvent;
        ScaleGame.Instance.EventRegister.UnpauseEventHandler -= OnUnpauseEvent;
        ScaleGame.Instance.EventRegister.GameStartEventHandler -= OnGameStartEvent;
        ScaleGame.Instance.EventRegister.GameStopEventHandler -= OnGameStopEvent;
    }

    private void OnPauseEvent(object _, PauseEvent @event)
    {
        SetupPauseMenuControls();
    }
    
    private void OnUnpauseEvent(object _, UnpauseEvent @event)
    {
        SetupInGameControls();
    }
    
    private void OnGameStartEvent(object _, GameStartEvent @event)
    {
        Debug.Log("InputManager enabled (game start)");
        controls.Enable();
    }
    
    private void OnGameStopEvent(object _, GameStopEvent @event)
    {
        Debug.Log("InputManager disabled (game stop)");
        controls.Disable();
    }
}