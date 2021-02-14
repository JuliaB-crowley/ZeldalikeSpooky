// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""MainController"",
            ""id"": ""70b333c8-43d9-41ea-b412-9ff543bb233f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""1531a241-fc12-4524-9db2-c3db67866fa7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""51e078bf-fcd0-4ee8-b35b-356aec30e354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ef6d2506-6663-434f-abaf-1c937b571a7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""HeavyAttack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a7b03126-8b37-4d3e-9013-c86f51348e34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1137028b-e995-4b9f-bdf2-8abd26d6875d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8e53c238-c261-47c3-b81c-ab6eea5d292b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5c01cb37-6786-415b-99a8-7dea2e1b5ad1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fef0d41c-5d86-4ff5-ac62-7fd35f40ff8a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dc3ed25a-f15c-4ab7-aa91-e2e5ac124e20"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f9085e6c-5d41-4ffe-a67b-c69cbc025a3a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14d9461a-f18b-4e5c-a905-d5ca4097dacf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""011fa760-4ece-4622-ba1d-32952f251491"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e8e66b2-7073-4692-8028-f7b3276f729f"",
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
                    ""id"": ""2d032730-7180-4f84-9d0d-1525fa28a82c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b763f81-f31f-4217-8703-be252593e513"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ada555d-206b-40b4-92ff-e2edb2665a3d"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HeavyAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainController
        m_MainController = asset.FindActionMap("MainController", throwIfNotFound: true);
        m_MainController_Move = m_MainController.FindAction("Move", throwIfNotFound: true);
        m_MainController_Roll = m_MainController.FindAction("Roll", throwIfNotFound: true);
        m_MainController_Attack = m_MainController.FindAction("Attack", throwIfNotFound: true);
        m_MainController_HeavyAttack = m_MainController.FindAction("HeavyAttack", throwIfNotFound: true);
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

    // MainController
    private readonly InputActionMap m_MainController;
    private IMainControllerActions m_MainControllerActionsCallbackInterface;
    private readonly InputAction m_MainController_Move;
    private readonly InputAction m_MainController_Roll;
    private readonly InputAction m_MainController_Attack;
    private readonly InputAction m_MainController_HeavyAttack;
    public struct MainControllerActions
    {
        private @Controller m_Wrapper;
        public MainControllerActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MainController_Move;
        public InputAction @Roll => m_Wrapper.m_MainController_Roll;
        public InputAction @Attack => m_Wrapper.m_MainController_Attack;
        public InputAction @HeavyAttack => m_Wrapper.m_MainController_HeavyAttack;
        public InputActionMap Get() { return m_Wrapper.m_MainController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainControllerActions set) { return set.Get(); }
        public void SetCallbacks(IMainControllerActions instance)
        {
            if (m_Wrapper.m_MainControllerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnMove;
                @Roll.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnRoll;
                @Attack.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnAttack;
                @HeavyAttack.started -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.performed -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHeavyAttack;
                @HeavyAttack.canceled -= m_Wrapper.m_MainControllerActionsCallbackInterface.OnHeavyAttack;
            }
            m_Wrapper.m_MainControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @HeavyAttack.started += instance.OnHeavyAttack;
                @HeavyAttack.performed += instance.OnHeavyAttack;
                @HeavyAttack.canceled += instance.OnHeavyAttack;
            }
        }
    }
    public MainControllerActions @MainController => new MainControllerActions(this);
    public interface IMainControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnHeavyAttack(InputAction.CallbackContext context);
    }
}
