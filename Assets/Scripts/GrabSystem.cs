using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    public GrabRadar m_Radar;

    public bool isObjectAtReach = false;
    public bool isGrabbing;

    public GameObject grabbedObj = null;
    Vector3 grabbedObjOffset;
    Transform nearHandTransform;

    public void SetAtReach(GameObject reachableObject, Transform handTransform)
    {
 
            nearHandTransform = handTransform;
            isObjectAtReach = true;
        
    }

    private void Update()
    {
        if (isObjectAtReach && Input.GetKey(KeyCode.C) && !isGrabbing)
        {
            isGrabbing = true;
            GrabObj(m_Radar.nearestGrabbleObject);
            return;
        }

        if (isGrabbing)
        {
            if (m_Radar.nearestGrabbleObject)
            {
                Rigidbody2D goRB = m_Radar.nearestGrabbleObject.GetComponent<Rigidbody2D>();
                var direction = goRB.transform.position - transform.position;
                goRB.AddForce(direction*10f);

                //m_Radar.nearestGrabbleObject.transform.position = nearHandTransform.position + grabbedObjOffset;
            }
            else
                m_Radar.nearestGrabbleObject = null;
        }

        if (Input.GetKey(KeyCode.C) && isGrabbing)
        {
            isGrabbing = false;
            return;
        }
    }

    void GrabObj(GameObject obj)
    {
        grabbedObjOffset = obj.transform.position - nearHandTransform.position;
    }

}
