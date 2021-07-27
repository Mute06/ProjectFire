using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particle;
    private bool isEmitting = false;
    public Vector2 velocity;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0.01f)
        {
            StartEmitting();
        }
        else
        {
            StopEmitting();
        }
    }
    public void StopEmitting() 
    {
        if (isEmitting)
        {
            particle.enableEmission = false;
            isEmitting = false;
        }
        
    }

    
    public void StartEmitting()
    {
        if (!isEmitting)
        {
            particle.enableEmission = true;
            isEmitting = true;
        }
    }

}
