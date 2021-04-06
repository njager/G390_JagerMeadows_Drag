// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/BoatTest.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BoatTest : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BoatTest()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BoatTest"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""719b532c-828d-4fcc-876b-a4ec3f1e74f1"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""642bb56a-9c83-4f3f-bc06-281efb25583e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""d110d9f8-8ee6-4513-ad66-d05c569107e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""6e933a61-19e5-45c0-a96a-69c30630890d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""5d5229b8-83ab-49bd-abd3-087d27214403"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""84925c16-f0e1-46ac-a589-bb6531126ff7"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26c0bda9-56b7-4944-a203-af1c30dd5619"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""553b8b8b-bc5c-435f-9752-f7d81f29cb91"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb38614d-625a-44d6-9fbe-6722578b4699"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Forward = m_Gameplay.FindAction("Forward", throwIfNotFound: true);
        m_Gameplay_Backward = m_Gameplay.FindAction("Backward", throwIfNotFound: true);
        m_Gameplay_Left = m_Gameplay.FindAction("Left", throwIfNotFound: true);
        m_Gameplay_Right = m_Gameplay.FindAction("Right", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Forward;
    private readonly InputAction m_Gameplay_Backward;
    private readonly InputAction m_Gameplay_Left;
    private readonly InputAction m_Gameplay_Right;
    public struct GameplayActions
    {
        private @BoatTest m_Wrapper;
        public GameplayActions(@BoatTest wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Gameplay_Forward;
        public InputAction @Backward => m_Wrapper.m_Gameplay_Backward;
        public InputAction @Left => m_Wrapper.m_Gameplay_Left;
        public InputAction @Right => m_Wrapper.m_Gameplay_Right;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnBackward;
                @Left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}
