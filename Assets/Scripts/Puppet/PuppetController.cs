using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetController : MonoBehaviour {


    public Rigidbody2D m_RLeg;
    public Rigidbody2D m_LLeg;

    public bool isRLegSelected;
    public bool isLLegSelected;

    public float dragSpeed;


    float upInput = 0f;
    float rightInput = 0f;
    float leftInput = 0f;
    float downInput = 0f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            upInput = 1f;
        }
        else
        {
            upInput = 0f;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftInput = 1f;
        }
        else
        {
            leftInput = 0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightInput = 1f;
        }
        else
        {
            rightInput = 0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            downInput = 1f;
        }
        else
        {
            downInput = 0f;
        }

        var moveDirection = new Vector2(upInput - downInput, leftInput - rightInput).normalized * dragSpeed;


        if (Input.GetKeyDown(KeyCode.D))
        {
            isLLegSelected = !isLLegSelected;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            isRLegSelected = !isLLegSelected;
        }

        if (isLLegSelected)
        {

            m_LLeg.velocity = moveDirection;

        }
        if (isRLegSelected)
        {

            m_RLeg.velocity = moveDirection;

        }

    }
}
