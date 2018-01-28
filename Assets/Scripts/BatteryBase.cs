using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryBase : MonoBehaviour
{
    public GameObject objectToActive = null;
    public AudioSource[] powerAudio;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObjectBattery")
        {
            powerAudio[0].Play();
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
            powerAudio[1].Play();
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
