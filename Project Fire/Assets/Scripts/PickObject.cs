using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObject : MonoBehaviour
{
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
        if (trigger.ListOfGameobjects.Count > 0)
        {
            if (selectedGameObject == null)
            {
                selectedGameObject = GetTheClosestObject();
            }
            
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

}
