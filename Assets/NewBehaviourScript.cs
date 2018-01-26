using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public HingeJoint2D heelR;
    public HingeJoint2D heelL;
    Rigidbody2D rbHellR;
    Rigidbody2D rbHellL;
    public Rigidbody2D body;
    public Transform alien;


    void Start()
    {
        rbHellR = heelR.GetComponent<Rigidbody2D>();
        rbHellL = heelL.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector3.right * 100);
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector3.left * 100);
        }

        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(Vector3.up * 100);
        }
    }

    private void LateUpdate()
    {
        Vector3 pos = alien.position;
        pos.x = body.position.x;
        alien.position = pos;
    }
}
