using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    public GameObject grabObject = null;
    public Vector3 grabOffset;
    public bool isObjectInRange = false;
    public bool onGrabbing = false;
    public Vector3 startingPosition;


    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (isObjectInRange)
        {
            if (Input.GetKey(KeyCode.C))
            {
                onGrabbing = true;
            }
            else
            {
                GrabbleObject grabble = grabObject.GetComponent<GrabbleObject>();
                grabble.isGrabbed = false;
                grabble.handObject = null;
                onGrabbing = false;
            }
        }
    }

    /*void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            if (!onGrabbing)
            {
                isObjectInRange = true;
                grabObject = collision.gameObject;
                grabOffset = grabObject.transform.position - transform.position;

                GrabbleObject grabble = grabObject.GetComponent<GrabbleObject>();
                grabble.handObject = gameObject;
                grabble.isGrabbed = true;
                grabble.grabOffset = grabOffset;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            isObjectInRange = false;
            grabObject = null;
        }
    }*/
}
