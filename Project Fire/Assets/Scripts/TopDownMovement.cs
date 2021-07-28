using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TopDownMovement : MonoBehaviour
{
    private InputHandler _input;
    public float moveSpeed;
    public float rotateSpeed;
    [Range(0.01f,1f)] public float acceleration;
    public LayerMask groundLayer;
    public Transform groundCheckPoint;
    public float jumpForce = 7f , radius;
    public ParticleSystem moveParticle;
    [SerializeField] private UnityEvent OnMoveEvent, OnStopEvet; 
    

    private Vector3 moveVector;
    private Camera cam;
    private Rigidbody rb;
    private Vector3 input;
    private bool isGrounded;
    private Vector3 smoothingSpeed = Vector3.zero;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheckPoint.position, radius, groundLayer);

        // Move in the direction we are aiming
        input = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);
        input = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0) * input;
        input.Normalize();
        moveVector = input * moveSpeed;



        // Rotate in the direction we are moving
        if (input.magnitude > 0) 
        {
            
            var targetRotation = Quaternion.LookRotation(input,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

            //transform.forward = input;

            OnMoveEvent.Invoke();

        }
        else
        {
            
            OnStopEvet.Invoke();
        }
        if (_input.jumpKey && isGrounded)
        {
            Jump();
        }
        
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + (moveVector * Time.fixedDeltaTime));
        
        rb.velocity = Vector3.SmoothDamp(rb.velocity,new Vector3(moveVector.x, rb.velocity.y, moveVector.z),ref smoothingSpeed ,acceleration);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

}
