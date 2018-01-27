using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleObject : MonoBehaviour
{
    public GameObject handObject = null;
    public Vector3 grabOffset;
    bool isHandContact = false;
    public bool isGrabbed = false;
        

    void Update()
    {
        if (isGrabbed)
        {
            transform.position = handObject.transform.position + grabOffset;
        }
    }
}
