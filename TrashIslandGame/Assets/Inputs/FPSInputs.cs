//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Inputs/FPSInputs.inputactions
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

public partial class @FPSInputs : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @FPSInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FPSInputs"",
    ""maps"": [
        {
            ""name"": ""Default"",
            ""id"": ""f64b7fcb-4b53-4a7a-b5ac-2bec29fac94b"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d89e23bc-03b8-4ff2-9309-83ede13fc3c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""d925dd0a-f2d6-43ed-a36d-3cfed439c161"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""4e44bb36-04ac-459b-9b9a-35af07f05de7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8413b5ef-09b7-4c60-97ed-32a8efa409d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Value"",
                    ""id"": ""3dd3c11a-247f-4fac-92d9-40afc7e17b37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""4728f74d-5c1a-4316-b56e-199005cffcad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Build"",
                    ""type"": ""Button"",
                    ""id"": ""55068f9a-22b5-4a2a-8805-658f98f4d375"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip1"",
                    ""type"": ""Button"",
                    ""id"": ""54683f6a-e701-4caf-9af1-eb46a06dfcba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Equip2"",
                    ""type"": ""Button"",
                    ""id"": ""cc87f192-8067-4edf-aeca-daec36aeb744"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0398a9ac-d631-4889-8875-264919f85271"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""276d07a0-9a6e-4caa-b970-292f741df9fa"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""4d2e777e-7b8b-49ce-a75e-eac265188c5a"",
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
                    ""id"": ""763b070b-f363-4559-8318-2fc5cd2ae5b2"",
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
                    ""id"": ""eb4fe8d4-6193-4750-9e55-1959d51b806d"",
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
                    ""id"": ""b2f8364e-31af-4b24-8c07-0c50f664e074"",
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
                    ""id"": ""1ef363a5-cccf-4187-b2c1-d279fd8e7929"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""aecfcd97-0ef7-4bc0-a3bb-2f13f618edac"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77f6aa9d-1f54-47b6-b8ca-a5a9539faf46"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""786d0e8f-d14a-4b27-9a5c-b3b278ac444d"",
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
                    ""id"": ""17807233-c2e4-4008-a90c-634737a0cd38"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Build"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60652aca-2197-4b9a-b2d3-e940374cc1f7"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae57647b-ff5c-4483-97b8-fd6fc02fd88f"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Default
        m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
        m_Default_Attack = m_Default.FindAction("Attack", throwIfNotFound: true);
        m_Default_Look = m_Default.FindAction("Look", throwIfNotFound: true);
        m_Default_Movement = m_Default.FindAction("Movement", throwIfNotFound: true);
        m_Default_Interact = m_Default.FindAction("Interact", throwIfNotFound: true);
        m_Default_Sprint = m_Default.FindAction("Sprint", throwIfNotFound: true);
        m_Default_Jump = m_Default.FindAction("Jump", throwIfNotFound: true);
        m_Default_Build = m_Default.FindAction("Build", throwIfNotFound: true);
        m_Default_Equip1 = m_Default.FindAction("Equip1", throwIfNotFound: true);
        m_Default_Equip2 = m_Default.FindAction("Equip2", throwIfNotFound: true);
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

    // Default
    private readonly InputActionMap m_Default;
    private IDefaultActions m_DefaultActionsCallbackInterface;
    private readonly InputAction m_Default_Attack;
    private readonly InputAction m_Default_Look;
    private readonly InputAction m_Default_Movement;
    private readonly InputAction m_Default_Interact;
    private readonly InputAction m_Default_Sprint;
    private readonly InputAction m_Default_Jump;
    private readonly InputAction m_Default_Build;
    private readonly InputAction m_Default_Equip1;
    private readonly InputAction m_Default_Equip2;
    public struct DefaultActions
    {
        private @FPSInputs m_Wrapper;
        public DefaultActions(@FPSInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Default_Attack;
        public InputAction @Look => m_Wrapper.m_Default_Look;
        public InputAction @Movement => m_Wrapper.m_Default_Movement;
        public InputAction @Interact => m_Wrapper.m_Default_Interact;
        public InputAction @Sprint => m_Wrapper.m_Default_Sprint;
        public InputAction @Jump => m_Wrapper.m_Default_Jump;
        public InputAction @Build => m_Wrapper.m_Default_Build;
        public InputAction @Equip1 => m_Wrapper.m_Default_Equip1;
        public InputAction @Equip2 => m_Wrapper.m_Default_Equip2;
        public InputActionMap Get() { return m_Wrapper.m_Default; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DefaultActions set) { return set.Get(); }
        public void SetCallbacks(IDefaultActions instance)
        {
            if (m_Wrapper.m_DefaultActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnAttack;
                @Look.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnLook;
                @Movement.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnInteract;
                @Sprint.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnJump;
                @Build.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnBuild;
                @Build.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnBuild;
                @Build.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnBuild;
                @Equip1.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEquip1;
                @Equip1.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEquip1;
                @Equip1.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEquip1;
                @Equip2.started -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEquip2;
                @Equip2.performed -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEquip2;
                @Equip2.canceled -= m_Wrapper.m_DefaultActionsCallbackInterface.OnEquip2;
            }
            m_Wrapper.m_DefaultActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Build.started += instance.OnBuild;
                @Build.performed += instance.OnBuild;
                @Build.canceled += instance.OnBuild;
                @Equip1.started += instance.OnEquip1;
                @Equip1.performed += instance.OnEquip1;
                @Equip1.canceled += instance.OnEquip1;
                @Equip2.started += instance.OnEquip2;
                @Equip2.performed += instance.OnEquip2;
                @Equip2.canceled += instance.OnEquip2;
            }
        }
    }
    public DefaultActions @Default => new DefaultActions(this);
    public interface IDefaultActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnBuild(InputAction.CallbackContext context);
        void OnEquip1(InputAction.CallbackContext context);
        void OnEquip2(InputAction.CallbackContext context);
    }
}
