using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistScript : MonoBehaviour
{
    //public float speed = 1;
    public float secondsToWait = 10;
    public float durationOfWait = 4;
    public float speed = 25;
    bool leftMovement = true;
    Rigidbody2D rb;
    Vector3 pointA;
    Vector3 pointB;
    float currentSpeed = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        pointA = transform.GetChild(0).transform.position;
        pointB = transform.GetChild(1).transform.position;
        currentSpeed = speed;
    }

    void LateUpdate()
    {
        StartCoroutine(Pause());

        if (transform.position.x <= pointA.x || transform.position.x >= pointB.x)
        {
            leftMovement = !leftMovement;
        }

        Vector3 pos = transform.position;

        if (leftMovement)
        {
            pos.x -= (currentSpeed/100) * Time.deltaTime;
        }
        else
        {
            pos.x += (currentSpeed/100) * Time.deltaTime;
        }

        transform.position = pos;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(secondsToWait);
        currentSpeed = 0;
        yield return new WaitForSeconds(durationOfWait);
        currentSpeed = speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        leftMovement = !leftMovement;
    }
}
