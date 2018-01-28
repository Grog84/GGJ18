using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject objectToActive = null;
    bool isActive = false;
    Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var myAngle = transform.rotation.eulerAngles.z;
        
        if (myAngle < 200)
        {
            if (myAngle >= 40)
            {
                isActive = true;
                rb.bodyType = RigidbodyType2D.Static;

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
    }
}
