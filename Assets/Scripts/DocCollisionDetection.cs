using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocCollisionDetection : MonoBehaviour {

    public AlienRay alienRay;

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.layer.ToString());
        if (other.gameObject.layer == 8)
        {
            alienRay.hasReachedGround = true;
        }
       
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log(other.gameObject.layer.ToString());
        if (other.gameObject.layer == 8)
        {
            alienRay.hasReachedGround = false;
        }
        else
        {

        }
    }
}
