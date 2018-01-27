using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBase : MonoBehaviour
{
    public GameObject objectToActive = null;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObjectBattery")
        {
            if (objectToActive != null)
            {
                objectToActive.GetComponent<DoorScript>().isActive = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObjectBattery")
        {
            if (objectToActive != null)
            {
                objectToActive.GetComponent<DoorScript>().isActive = false;
            }
        }
    }
}
