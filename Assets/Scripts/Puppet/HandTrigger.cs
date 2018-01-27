using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    public GrabSystem grabSystem;


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            if (!grabSystem.onGrabbing)
            {
                grabSystem.isObjectInRange = true;
                grabSystem.grabObject = collision.gameObject;
                grabSystem.grabOffset = grabSystem.grabObject.transform.position - transform.position;

                GrabbleObject grabble = grabSystem.grabObject.GetComponent<GrabbleObject>();
                grabble.handObject = gameObject;
                grabble.isGrabbed = true;
                grabble.grabOffset = grabSystem.grabOffset;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            grabSystem.isObjectInRange = false;
            grabSystem.grabObject = null;
        }
    }
}
