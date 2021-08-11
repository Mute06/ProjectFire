using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideTrigger : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    public List<GameObject> ListOfGameobjects = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (IsInLayerMask(other.gameObject, layerMask) && !ListOfGameobjects.Contains(other.gameObject))
        {
            ListOfGameobjects.Add(other.gameObject);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (ListOfGameobjects.Contains(other.gameObject))
        {
            ListOfGameobjects.Remove(other.gameObject);

        }
    }

    /// <summary>
    /// A function that checks if a gameobjects layer is inside a layermask
    /// </summary>
    /// <param name="GameObject to Check"></param>
    /// <param name="LayerMask"></param>
    /// <returns></returns>
    private bool IsInLayerMask(GameObject obj, LayerMask layerMask)
    {
        return ((layerMask.value & (1 << obj.layer)) > 0);
    }
}
