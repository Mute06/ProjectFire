// GENERATED AUTOMATICALLY FROM 'Assets/Stuff/Input/Touch.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Touch : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Touch()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Touch"",
    ""maps"": [
        {
            ""name"": ""TouchInputs"",
            ""id"": ""452dfc33-9682-4646-8589-a8ce6441ddd6"",
            ""actions"": [
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e9647b87-6d7a-4386-a232-b0fc7b9e8cc3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""isTouchHolding"",
                    ""type"": ""Button"",
                    ""id"": ""ecbed34d-4fcf-4007-99b6-a72246ee3a3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c79f1f6-ae66-4b36-9291-d7e522d4e955"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c48a847-4157-4f3c-b157-3ed830c13821"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""isTouchHolding"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // TouchInputs
        m_TouchInputs = asset.FindActionMap("TouchInputs", throwIfNotFound: true);
        m_TouchInputs_TouchPosition = m_TouchInputs.FindAction("TouchPosition", throwIfNotFound: true);
        m_TouchInputs_isTouchHolding = m_TouchInputs.FindAction("isTouchHolding", throwIfNotFound: true);
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

    // TouchInputs
    private readonly InputActionMap m_TouchInputs;
    private ITouchInputsActions m_TouchInputsActionsCallbackInterface;
    private readonly InputAction m_TouchInputs_TouchPosition;
    private readonly InputAction m_TouchInputs_isTouchHolding;
    public struct TouchInputsActions
    {
        private @Touch m_Wrapper;
        public TouchInputsActions(@Touch wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPosition => m_Wrapper.m_TouchInputs_TouchPosition;
        public InputAction @isTouchHolding => m_Wrapper.m_TouchInputs_isTouchHolding;
        public InputActionMap Get() { return m_Wrapper.m_TouchInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchInputsActions set) { return set.Get(); }
        public void SetCallbacks(ITouchInputsActions instance)
        {
            if (m_Wrapper.m_TouchInputsActionsCallbackInterface != null)
            {
                @TouchPosition.started -= m_Wrapper.m_TouchInputsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_TouchInputsActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_TouchInputsActionsCallbackInterface.OnTouchPosition;
                @isTouchHolding.started -= m_Wrapper.m_TouchInputsActionsCallbackInterface.OnİsTouchHolding;
                @isTouchHolding.performed -= m_Wrapper.m_TouchInputsActionsCallbackInterface.OnİsTouchHolding;
                @isTouchHolding.canceled -= m_Wrapper.m_TouchInputsActionsCallbackInterface.OnİsTouchHolding;
            }
            m_Wrapper.m_TouchInputsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @isTouchHolding.started += instance.OnİsTouchHolding;
                @isTouchHolding.performed += instance.OnİsTouchHolding;
                @isTouchHolding.canceled += instance.OnİsTouchHolding;
            }
        }
    }
    public TouchInputsActions @TouchInputs => new TouchInputsActions(this);
    public interface ITouchInputsActions
    {
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnİsTouchHolding(InputAction.CallbackContext context);
    }
}
