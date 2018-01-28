using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStrangeScript : MonoBehaviour
{
    public GameObject objectToActive = null;
    bool isActive = false;
    GameObject switchStrange;
    Rigidbody2D rb;


    void Start()
    {
        rb = transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
        switchStrange = transform.GetChild(0).gameObject;
    }
	
	
	void Update ()
    {
        if (!isActive)
        {
            if (switchStrange.transform.localPosition.x <= -1)
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
