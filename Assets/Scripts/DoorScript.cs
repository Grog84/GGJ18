using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : TriggerEffect
{
    public float speed = 1;
    public float pointY = 1;
    Vector3 startPos;


    void Start()
    {
        startPos = transform.position;
    }

    void Update ()
    {
        Vector3 pos = transform.position;

        if (isActive)
        {
            if (transform.position.y < pointY)
            {
                pos.y += speed * Time.deltaTime;
            }
        }
        else
        {
            if (transform.position.y > startPos.y)
            {
                pos.y -= speed * Time.deltaTime;
            }
        }

        transform.position = pos;
    }
}
