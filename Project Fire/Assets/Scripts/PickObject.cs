using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
    [SerializeField] Transform holdPoint;
    private InputHandler _input;
    [SerializeField] private InsideTrigger trigger;
    private GameObject selectedGameObject;
    private bool isHolding;


    private void Awake()
    {
        _input = GetComponent<InputHandler>();

    }

    private void OnEnable()
    {
        _input.OnInteractKeyPressed += OnIntreactPressed;
    }

    private void OnDisable()
    {
        _input.OnInteractKeyPressed -= OnIntreactPressed;
    }

    private void OnIntreactPressed()
    {
        //Pick up the Object
        if (!isHolding)
        {
            if (trigger.ListOfGameobjects.Count > 0)
            {
                if (selectedGameObject == null)
                {
                    selectedGameObject = GetTheClosestObject();
                    PickTheObject(selectedGameObject);
                }

            }
        }

        // Drop The Object
        else if (selectedGameObject != null)
        {
            DropTheObject(selectedGameObject);
        }
    }

    private GameObject GetTheClosestObject()
    {
        GameObject closestObject = null;
        float closestDist = 100;
        foreach (var item in trigger.ListOfGameobjects)
        {
            float dist = Vector3.Distance(item.transform.position, transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestObject = item.gameObject;
            }
        }
        return closestObject;
    }

    private void PickTheObject(GameObject selectedObject)
    {
        isHolding = true;
        var selectedRb = selectedGameObject.GetComponent<Rigidbody>();
        selectedRb.isKinematic = true;
        selectedObject.transform.position = holdPoint.position; 
        selectedObject.transform.SetParent(holdPoint);
        selectedObject.transform.rotation = Quaternion.identity;

        selectedObject.GetComponent<Collider>().enabled = false;


    }

    private void DropTheObject(GameObject selectedObject)
    {
        isHolding = false;
        selectedGameObject = null;
        var selectedRb = selectedObject.GetComponent<Rigidbody>();
        selectedRb.isKinematic = false;
        selectedObject.transform.SetParent(null);

        selectedObject.GetComponent<Collider>().enabled = true;
    }
        

}
