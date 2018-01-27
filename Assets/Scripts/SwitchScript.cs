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
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        var myAngle = transform.rotation.eulerAngles.z;
        
        if (myAngle < 300)
        {
            if (myAngle >= 40)
            {
                isActive = true;
                rb.bodyType = RigidbodyType2D.Static;

                if (objectToActive != null)
                {
                    objectToActive.GetComponent<DoorScript>().isActive = true;
                }
            }      
        }
    }
}
