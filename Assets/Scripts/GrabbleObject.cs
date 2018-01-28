using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleObject : MonoBehaviour
{
    public Transform hand = null;
    public Vector3 grabOffset;
    public bool isGrabbed;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void StartFollowing(Vector3 offset, Transform handTrans)
    {
        isGrabbed = true;
        grabOffset = offset;
        hand = handTrans;
        rb.freezeRotation = true;
    }

    public void StopFollowing()
    {
        isGrabbed = false;
        grabOffset = Vector3.zero;
        hand = null;
        rb.freezeRotation = false;
    }

    void Update()
    {
        if (isGrabbed)
        {
            transform.position = hand.transform.position + grabOffset;
        }
    }
}
