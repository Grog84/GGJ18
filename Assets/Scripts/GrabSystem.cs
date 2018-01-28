using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    public GrabRadar m_Radar;
    AlienRay alienray;

    public bool isObjectAtReach = false;
    public bool isGrabbing;

    public GameObject grabbedObj = null;
    Vector3 grabbedObjOffset;
    Transform nearHandTransform;

    Vector3[] lastPositions = new Vector3[10];
    int lastPositionIdx = 0;

    Rigidbody2D rb;

    public BoxCollider2D[] switchCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        alienray = FindObjectOfType<AlienRay>();
    }

    public void SetAtReach(GameObject reachableObject, Transform handTransform)
    {
 
        nearHandTransform = handTransform;
        isObjectAtReach = true;
        
    }

    public void SetNomoreAtReach()
    {
        //isObjectAtReach = false;
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
            lastPositions[lastPositionIdx] = alienray.transform.position;
            lastPositionIdx++;
            lastPositionIdx %= 5;

            if (m_Radar.nearestGrabbleObject)
            {


                //Rigidbody2D goRB = m_Radar.nearestGrabbleObject.GetComponent<Rigidbody2D>();
                //var direction = transform.position - goRB.transform.position;
                //goRB.AddForce(direction*10f);

                //m_Radar.nearestGrabbleObject.transform.position = nearHandTransform.position + grabbedObjOffset;

            }
            else
                m_Radar.nearestGrabbleObject = null;
        }

        if (Input.GetKeyUp(KeyCode.C) && isGrabbing)
        {
            isGrabbing = false;
            grabbedObj.GetComponent<GrabbleObject>().StopFollowing();

            Vector3 force = Vector3.zero;
            Vector3 diff = Vector3.zero;

            if (lastPositionIdx == 0)
            {
                diff = (lastPositions[9] - lastPositions[0]);
                var direction = diff.normalized;
                force = direction * diff.sqrMagnitude * 10f; // hard coded value

            }
            else
            {
                diff = (lastPositions[0] - lastPositions[9]);
                var direction = diff.normalized;
                force = direction * diff.sqrMagnitude * 10f; // hard coded value
            }

            //grabbedObj.GetComponent<GrabbleObject>().rb.velocity = rb.velocity;
            //grabbedObj.transform.parent = null;

            grabbedObj.GetComponent<GrabbleObject>().rb.isKinematic = false;
            grabbedObj.GetComponent<GrabbleObject>().rb.AddForce(new Vector2(force.x, force.y));
            grabbedObj = null;
            StartCoroutine(ReEnableColliders());
            return;
        }
    }

    void GrabObj(GameObject obj)
    {
        if (grabbedObj == null)
        {
            grabbedObj = obj;
            grabbedObjOffset = obj.transform.position - nearHandTransform.position;
            //obj.GetComponent<GrabbleObject>().isGrabbed = true;
            obj.GetComponent<GrabbleObject>().StartFollowing(grabbedObjOffset, nearHandTransform);
            DisableColliders();
            // obj.transform.parent = nearHandTransform;

        }
    }

    void EnableColliders()
    {
        foreach (var coll in switchCollider)
        {
            coll.isTrigger = false;
        }

    }

    void DisableColliders()
    {
        foreach (var coll in switchCollider)
        {
            coll.isTrigger = true;
        }

    }

    IEnumerator ReEnableColliders()
    {
        yield return new WaitForSeconds(1f);
        EnableColliders();
        yield return null;

    }

}
