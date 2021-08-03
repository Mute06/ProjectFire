using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    [HideInInspector] public bool isDraging;
    [HideInInspector] public Vector3 desiredPosition;
    [SerializeField] private float speed;

    private void Update()
    {
        if (isDraging)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
        }
    }

}
