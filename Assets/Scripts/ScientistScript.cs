using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistScript : MonoBehaviour
{
    public float speed = 1;
    bool leftMovement = true;
    Rigidbody2D rb;
    Vector3 pointA;
    Vector3 pointB;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        pointA = transform.GetChild(0).transform.position;
        pointB = transform.GetChild(1).transform.position;
    }

    void Update()
    {
        if (transform.position.x <= pointA.x || transform.position.x >= pointB.x)
        {
            leftMovement = !leftMovement;
        }

        Vector3 pos = transform.position;

        if (leftMovement)
        {
            pos.x -= (speed/100) * Time.deltaTime;
        }
        else
        {
            pos.x += (speed/100) * Time.deltaTime;
        }

        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        leftMovement = !leftMovement;
    }
}
