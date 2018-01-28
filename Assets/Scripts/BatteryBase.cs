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
                if (objectToActive.GetComponent<DoorScript>() != null)
                {
                    objectToActive.GetComponent<DoorScript>().isActive = true;
                }
                else if (objectToActive.GetComponent<Door2PiecesScript>() != null)
                {
                    objectToActive.GetComponent<Door2PiecesScript>().isActive = true;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObjectBattery")
        {
            if (objectToActive != null)
            {
                if (objectToActive.GetComponent<DoorScript>() != null)
                {
                    objectToActive.GetComponent<DoorScript>().isActive = false;
                }
                else if (objectToActive.GetComponent<Door2PiecesScript>() != null)
                {
                    objectToActive.GetComponent<Door2PiecesScript>().isActive = false;
                }
            }
        }
    }
}
