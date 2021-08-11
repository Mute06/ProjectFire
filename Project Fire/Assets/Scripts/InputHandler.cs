using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Controls controls = null;

    public Vector2 InputVector { get; private set; }
    public bool jumpKey { get; private set; }
    public float mouseDelta { get; private set; }

    public bool InteractKey { get; private set; }
    public delegate void InteractKeyPressed();
    public event InteractKeyPressed OnInteractKeyPressed;

    // Creating instance of controls
    private void Awake()
    {
        controls = new Controls(); 
    }

    private void Start()
    {
        controls.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        OnInteractKeyPressed();
    }

    //Disableing and Enabling the Controls
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Update()
    {
        //Movement Vector
        InputVector = controls.Player.Movement.ReadValue<Vector2>();
        //Jump
        jumpKey = controls.Player.Jump.triggered;

        //Interact button
        InteractKey = controls.Player.Interact.triggered;
    }

}
