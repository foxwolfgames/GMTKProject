//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Player/Input/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""26a80904-5c8f-46b3-80dd-884ffb05269b"",
            ""actions"": [
                {
                    ""name"": ""HorizontalMovement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""df146681-0467-4020-b984-7231596c6d3a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraMovementX"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7e70ea12-9abd-4e73-a304-23ea3e1f455a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CameraMovementY"",
                    ""type"": ""PassThrough"",
                    ""id"": ""82b64e94-564a-46d6-91ba-4153fb0547e3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c96231a8-5cf6-43c0-a4f5-ec423da9fc65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""7689fa74-a11f-4425-b636-d65fdb333bd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""76c95a02-9b10-4832-8ac5-6775b8a35ada"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5faa1641-18ff-4f0a-a5fd-759ae2691e88"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""91ca9d04-64d4-468c-b601-5aff329d35f8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dac9d850-cb09-490f-bfdf-9bcdc1ee0d5a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a81d95d8-cac9-465f-ad16-b628e1ff4f4f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""06f8027d-0831-4f4d-8eaf-4e408929dd51"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b54857bd-37e2-4322-ae73-48f2f5095d6d"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0144e3ab-ad26-440a-8707-1b2ffe82d574"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""255af702-badd-45ba-ab3f-c5ab51c876b5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerInteraction"",
            ""id"": ""72db065d-2687-4c6d-90a0-e600d6341adf"",
            ""actions"": [
                {
                    ""name"": ""GrabAction"",
                    ""type"": ""Button"",
                    ""id"": ""826fe3ce-4d4a-41ec-a82d-d65a11ec7f4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ceec53de-2126-41d3-8dca-d8de98088ab7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GrabAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_HorizontalMovement = m_PlayerMovement.FindAction("HorizontalMovement", throwIfNotFound: true);
        m_PlayerMovement_CameraMovementX = m_PlayerMovement.FindAction("CameraMovementX", throwIfNotFound: true);
        m_PlayerMovement_CameraMovementY = m_PlayerMovement.FindAction("CameraMovementY", throwIfNotFound: true);
        m_PlayerMovement_Jump = m_PlayerMovement.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMovement_Sprint = m_PlayerMovement.FindAction("Sprint", throwIfNotFound: true);
        // PlayerInteraction
        m_PlayerInteraction = asset.FindActionMap("PlayerInteraction", throwIfNotFound: true);
        m_PlayerInteraction_GrabAction = m_PlayerInteraction.FindAction("GrabAction", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private List<IPlayerMovementActions> m_PlayerMovementActionsCallbackInterfaces = new List<IPlayerMovementActions>();
    private readonly InputAction m_PlayerMovement_HorizontalMovement;
    private readonly InputAction m_PlayerMovement_CameraMovementX;
    private readonly InputAction m_PlayerMovement_CameraMovementY;
    private readonly InputAction m_PlayerMovement_Jump;
    private readonly InputAction m_PlayerMovement_Sprint;
    public struct PlayerMovementActions
    {
        private @InputActions m_Wrapper;
        public PlayerMovementActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @HorizontalMovement => m_Wrapper.m_PlayerMovement_HorizontalMovement;
        public InputAction @CameraMovementX => m_Wrapper.m_PlayerMovement_CameraMovementX;
        public InputAction @CameraMovementY => m_Wrapper.m_PlayerMovement_CameraMovementY;
        public InputAction @Jump => m_Wrapper.m_PlayerMovement_Jump;
        public InputAction @Sprint => m_Wrapper.m_PlayerMovement_Sprint;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Add(instance);
            @HorizontalMovement.started += instance.OnHorizontalMovement;
            @HorizontalMovement.performed += instance.OnHorizontalMovement;
            @HorizontalMovement.canceled += instance.OnHorizontalMovement;
            @CameraMovementX.started += instance.OnCameraMovementX;
            @CameraMovementX.performed += instance.OnCameraMovementX;
            @CameraMovementX.canceled += instance.OnCameraMovementX;
            @CameraMovementY.started += instance.OnCameraMovementY;
            @CameraMovementY.performed += instance.OnCameraMovementY;
            @CameraMovementY.canceled += instance.OnCameraMovementY;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
        }

        private void UnregisterCallbacks(IPlayerMovementActions instance)
        {
            @HorizontalMovement.started -= instance.OnHorizontalMovement;
            @HorizontalMovement.performed -= instance.OnHorizontalMovement;
            @HorizontalMovement.canceled -= instance.OnHorizontalMovement;
            @CameraMovementX.started -= instance.OnCameraMovementX;
            @CameraMovementX.performed -= instance.OnCameraMovementX;
            @CameraMovementX.canceled -= instance.OnCameraMovementX;
            @CameraMovementY.started -= instance.OnCameraMovementY;
            @CameraMovementY.performed -= instance.OnCameraMovementY;
            @CameraMovementY.canceled -= instance.OnCameraMovementY;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
        }

        public void RemoveCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // PlayerInteraction
    private readonly InputActionMap m_PlayerInteraction;
    private List<IPlayerInteractionActions> m_PlayerInteractionActionsCallbackInterfaces = new List<IPlayerInteractionActions>();
    private readonly InputAction m_PlayerInteraction_GrabAction;
    public struct PlayerInteractionActions
    {
        private @InputActions m_Wrapper;
        public PlayerInteractionActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @GrabAction => m_Wrapper.m_PlayerInteraction_GrabAction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInteraction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInteractionActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerInteractionActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerInteractionActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerInteractionActionsCallbackInterfaces.Add(instance);
            @GrabAction.started += instance.OnGrabAction;
            @GrabAction.performed += instance.OnGrabAction;
            @GrabAction.canceled += instance.OnGrabAction;
        }

        private void UnregisterCallbacks(IPlayerInteractionActions instance)
        {
            @GrabAction.started -= instance.OnGrabAction;
            @GrabAction.performed -= instance.OnGrabAction;
            @GrabAction.canceled -= instance.OnGrabAction;
        }

        public void RemoveCallbacks(IPlayerInteractionActions instance)
        {
            if (m_Wrapper.m_PlayerInteractionActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerInteractionActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerInteractionActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerInteractionActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerInteractionActions @PlayerInteraction => new PlayerInteractionActions(this);
    public interface IPlayerMovementActions
    {
        void OnHorizontalMovement(InputAction.CallbackContext context);
        void OnCameraMovementX(InputAction.CallbackContext context);
        void OnCameraMovementY(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
    public interface IPlayerInteractionActions
    {
        void OnGrabAction(InputAction.CallbackContext context);
    }
}
