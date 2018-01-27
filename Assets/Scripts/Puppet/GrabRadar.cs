using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRadar : MonoBehaviour
{
    public List<GameObject> nearGrabbleObjects = new List<GameObject>();
    GameObject nearestGrabbleObject = null;
    public GrabSystem handLeft;
    public GrabSystem handRight;

    
    void Update()
    {
        if (nearGrabbleObjects.Count > 0 && (!handLeft.isObjectInRange && !handRight.isObjectInRange))
        {
            if (nearestGrabbleObject != null)
            {
                handLeft.transform.position = nearestGrabbleObject.transform.position;
                handRight.transform.position = nearestGrabbleObject.transform.position;
            }
        }
    }


    void GetNearestObject()
    {
        GameObject nearestObjectTemp = null;

        foreach (GameObject grabbleObject in nearGrabbleObjects)
        {
            if (nearestObjectTemp == null)
            {
                nearestObjectTemp = grabbleObject;
            }
            else
            {
                if (Vector3.SqrMagnitude(transform.position - grabbleObject.transform.position) < Vector3.SqrMagnitude(transform.position - nearestObjectTemp.transform.position))
                {
                    nearestObjectTemp = grabbleObject;
                }
            }
        }

        nearestGrabbleObject = nearestObjectTemp;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            bool itemExists = false;

            foreach (GameObject grabbleObject in nearGrabbleObjects)
            {
                if (collision.gameObject == grabbleObject)
                {
                    itemExists = true;
                    break;
                }               
            }

            if (!itemExists)
            {
                nearGrabbleObjects.Add(collision.gameObject);
            }
        }

        GetNearestObject();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            int index = nearGrabbleObjects.IndexOf(collision.gameObject);
            if (index != -1)
            {
                nearGrabbleObjects.RemoveAt(index);
            }
        }

        GetNearestObject();
    }
}
