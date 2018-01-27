using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRay : MonoBehaviour
{
    public Rigidbody2D body;
    public Transform alienRay;


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector3.right * 1, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector3.left * 1, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            body.velocity = Vector3.up * 1;
                //body.AddForce(Vector3.up * 10000, ForceMode2D. Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            body.velocity = Vector3.down * 1;
            //body.AddForce(Vector3.up * 10000, ForceMode2D. Impulse);
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = alienRay.position;
        pos.x = body.position.x;
        alienRay.position = pos;
    }
}
