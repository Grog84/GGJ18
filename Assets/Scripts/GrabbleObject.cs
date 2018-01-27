using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleObject : MonoBehaviour
{
    public GameObject handObject = null;
    [HideInInspector] public Vector3 grabOffset;
    [HideInInspector] bool isHandContact = false;
    [HideInInspector] public bool isGrabbed = false;
        

    void Update()
    {
        if (isGrabbed)
        {
            transform.position = handObject.transform.position + grabOffset;
        }
    }
}
