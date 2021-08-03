using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects : MonoBehaviour
{
    [SerializeField] private TouchInputManager touchInput;
    private Camera cameraMain;
    private bool isDraging;
    private GameObject currentObject;
    private DragableObject currentObjectsScript;
    

    private void Awake()
    {
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        touchInput.OnStartTouch += MoveStart;
        touchInput.OnHoldTouch += Move;
        touchInput.OnEndTouch += MoveEnd;
    }



    private void OnDisable()
    {
        touchInput.OnStartTouch -= MoveStart;
        touchInput.OnHoldTouch -= Move;
        touchInput.OnEndTouch -= MoveEnd;
    }

    public void MoveStart(Vector2 position)
    {
        
        Vector3 screenCoordinates = new Vector3(position.x, position.y, cameraMain.nearClipPlane);
        Ray ray = cameraMain.ScreenPointToRay(screenCoordinates);
        RaycastHit currentHit;
        Physics.Raycast(ray,out currentHit);
        if (currentHit.collider.CompareTag("Dragable"))
        {

            isDraging = true;
            currentObject = currentHit.collider.gameObject;
            currentObjectsScript = currentObject.GetComponent<DragableObject>();
            currentObjectsScript.isDraging = true;
        }
    }
    private void Move(Vector2 position)
    {
        if (isDraging && currentObject != null)
        {
            Vector3 screenCoordinates = new Vector3(position.x, position.y, cameraMain.nearClipPlane);
            Ray ray = cameraMain.ScreenPointToRay(screenCoordinates);
            RaycastHit currentHit;
            Physics.Raycast(ray, out currentHit);
            if (currentHit.collider != null && currentHit.collider.CompareTag("MoveableArea"))
            {
                //currentObject.transform.position = currentHit.point;
                currentObjectsScript.desiredPosition = currentHit.point;
            }
        }
    }
    private void MoveEnd(Vector2 position)
    {
        if (isDraging && currentObject != null)
        {
            isDraging = false;
            currentObject = null;
            currentObjectsScript.isDraging = false;
            currentObjectsScript = null;
        }
    }
}
