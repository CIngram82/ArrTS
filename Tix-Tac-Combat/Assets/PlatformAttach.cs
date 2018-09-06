using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour {

    private GameObject[] objects;
    

    private void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("MoveByPlatform");
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject obj in objects)
        { 
            if (other.gameObject == obj)
            {
                obj.transform.parent = transform;
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject obj in objects)
        {
            if (other.gameObject == obj)
            {
                obj.transform.parent = null;
            }
        }
    }
}
