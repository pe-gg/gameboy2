//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Input/CharacterInput.inputactions
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

public partial class @CharacterInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""CharacterMovement"",
            ""id"": ""1e57baa6-bf33-4258-a91c-c5b670509a61"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""861282f7-455a-43e8-b20c-9d558d237ea3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""1c92200e-37bc-4745-afeb-7bc9ae60d128"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f6a3b5f2-883f-4b1b-a43a-a03fa925ee22"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""96744106-f994-4934-845e-b3c83e355fb8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""27a8349c-534b-4b59-b5ba-a46b27183448"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d1378a5c-62c1-4e2d-b88e-1d829bc379fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""bf941f81-678b-4d4d-9dc3-5505f705fd7e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""312ecff3-16e3-44a5-a5b8-f7a48349dfb1"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""94ca24b5-b0ce-4c55-852c-6c76d7d45865"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0e5678fd-7384-433c-9ea9-1e65e5a8f262"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0127630b-7e56-40e2-b376-781d38396421"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""CharacterActions"",
            ""id"": ""f8efa5bb-d8e6-460c-9bb1-ee25cd527e86"",
            ""actions"": [
                {
                    ""name"": ""AButton"",
                    ""type"": ""Button"",
                    ""id"": ""4d8e8b7c-e9c6-45fd-bf77-e634903d7e2f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""BButton"",
                    ""type"": ""Button"",
                    ""id"": ""5f6809b4-985d-4755-bea7-bb29a2054969"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""73ae244a-ebae-4ff1-981f-24553ec0bcd0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d12180d-bb02-4a03-a0f5-fcf7fff5b9d6"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc3a7f55-f9ee-41f8-ae57-2a0d2b2f13a6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""682bb5dd-b711-4db5-a4ed-87e86dff35d6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterMovement
        m_CharacterMovement = asset.FindActionMap("CharacterMovement", throwIfNotFound: true);
        m_CharacterMovement_Movement = m_CharacterMovement.FindAction("Movement", throwIfNotFound: true);
        // CharacterActions
        m_CharacterActions = asset.FindActionMap("CharacterActions", throwIfNotFound: true);
        m_CharacterActions_AButton = m_CharacterActions.FindAction("AButton", throwIfNotFound: true);
        m_CharacterActions_BButton = m_CharacterActions.FindAction("BButton", throwIfNotFound: true);
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

    // CharacterMovement
    private readonly InputActionMap m_CharacterMovement;
    private List<ICharacterMovementActions> m_CharacterMovementActionsCallbackInterfaces = new List<ICharacterMovementActions>();
    private readonly InputAction m_CharacterMovement_Movement;
    public struct CharacterMovementActions
    {
        private @CharacterInput m_Wrapper;
        public CharacterMovementActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CharacterMovement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_CharacterMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterMovementActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(ICharacterMovementActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(ICharacterMovementActions instance)
        {
            if (m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterMovementActions @CharacterMovement => new CharacterMovementActions(this);

    // CharacterActions
    private readonly InputActionMap m_CharacterActions;
    private List<ICharacterActionsActions> m_CharacterActionsActionsCallbackInterfaces = new List<ICharacterActionsActions>();
    private readonly InputAction m_CharacterActions_AButton;
    private readonly InputAction m_CharacterActions_BButton;
    public struct CharacterActionsActions
    {
        private @CharacterInput m_Wrapper;
        public CharacterActionsActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @AButton => m_Wrapper.m_CharacterActions_AButton;
        public InputAction @BButton => m_Wrapper.m_CharacterActions_BButton;
        public InputActionMap Get() { return m_Wrapper.m_CharacterActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActionsActions set) { return set.Get(); }
        public void AddCallbacks(ICharacterActionsActions instance)
        {
            if (instance == null || m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Add(instance);
            @AButton.started += instance.OnAButton;
            @AButton.performed += instance.OnAButton;
            @AButton.canceled += instance.OnAButton;
            @BButton.started += instance.OnBButton;
            @BButton.performed += instance.OnBButton;
            @BButton.canceled += instance.OnBButton;
        }

        private void UnregisterCallbacks(ICharacterActionsActions instance)
        {
            @AButton.started -= instance.OnAButton;
            @AButton.performed -= instance.OnAButton;
            @AButton.canceled -= instance.OnAButton;
            @BButton.started -= instance.OnBButton;
            @BButton.performed -= instance.OnBButton;
            @BButton.canceled -= instance.OnBButton;
        }

        public void RemoveCallbacks(ICharacterActionsActions instance)
        {
            if (m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICharacterActionsActions instance)
        {
            foreach (var item in m_Wrapper.m_CharacterActionsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CharacterActionsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CharacterActionsActions @CharacterActions => new CharacterActionsActions(this);
    public interface ICharacterMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface ICharacterActionsActions
    {
        void OnAButton(InputAction.CallbackContext context);
        void OnBButton(InputAction.CallbackContext context);
    }
}
