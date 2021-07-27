using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float inputSmoothnes;
    public Vector2 InputVector { get; private set; }
    public Vector3 MousePosition { get; private set; }
    public bool jumpKey { get; private set; }

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        InputVector =new Vector2(h, v);
        MousePosition = Input.mousePosition;
        jumpKey = Input.GetButtonDown("Jump");

    }
}
