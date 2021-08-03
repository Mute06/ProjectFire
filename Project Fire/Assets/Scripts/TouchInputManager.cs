using System;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class TouchInputManager : MonoBehaviour
{
    public delegate void StartTouchEvent(Vector2 position);
    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent(Vector2 position);
    public event EndTouchEvent OnEndTouch;

    public delegate void HoldTouchEvent(Vector2 position);
    public event HoldTouchEvent OnHoldTouch;

    private Touch touchControls;

    private void Awake()
    {
        touchControls = new Touch();
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }
    private void OnDisable()
    {
        touchControls.Disable();
    }

    private void Start()
    {
        touchControls.TouchInputs.isTouchHolding.started += ctx => StartTouch(ctx);
        touchControls.TouchInputs.isTouchHolding.canceled += ctx => EndTouch(ctx);
        touchControls.TouchInputs.TouchPosition.performed += ctx => HoldingTouch(ctx);
    }

    private void HoldingTouch(InputAction.CallbackContext ctx)
    {
        if (OnHoldTouch != null)
        {
            OnHoldTouch(ctx.ReadValue<Vector2>());
        }
    }

    private void EndTouch(InputAction.CallbackContext ctx)
    {
        
        if (OnEndTouch != null)
        {
            OnEndTouch(touchControls.TouchInputs.TouchPosition.ReadValue<Vector2>());
        }
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        
        //Checks if event is using by someone
        if (OnStartTouch != null)
        {
            OnStartTouch(touchControls.TouchInputs.TouchPosition.ReadValue<Vector2>());
        }
    }
}
