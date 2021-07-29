using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform followObject;
    void LateUpdate()
    {
        transform.position = followObject.position;
    }
}
