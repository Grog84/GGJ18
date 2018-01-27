using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKTarget : MonoBehaviour {

    public bool isActive;

    public Transform referencePoint;
    public float maxDistanceSq;
    public float moveSpeed;

    Vector3 targetPos;

    private void Start()
    {
        maxDistanceSq = Vector3.SqrMagnitude(referencePoint.position - transform.position);
    }

    // Update is called once per frame
    void Update() {

        if (isActive)
        {
            Move();
        }

	}

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var curpos = transform.position;
            targetPos = new Vector3(curpos.x - moveSpeed, curpos.y, curpos.z);
            if(Vector3.SqrMagnitude(targetPos - referencePoint.transform.position) < maxDistanceSq)
                transform.position = targetPos;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            var curpos = transform.position;
            targetPos = new Vector3(curpos.x + moveSpeed, curpos.y, curpos.z);
            if (Vector3.SqrMagnitude(targetPos - referencePoint.transform.position) < maxDistanceSq)
                transform.position = targetPos;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            var curpos = transform.position;
            targetPos = new Vector3(curpos.x, curpos.y + moveSpeed, curpos.z);
            if (Vector3.SqrMagnitude(targetPos - referencePoint.transform.position) < maxDistanceSq)
                transform.position = targetPos;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            var curpos = transform.position;
            targetPos = new Vector3(curpos.x, curpos.y - moveSpeed, curpos.z);
            if (Vector3.SqrMagnitude(targetPos - referencePoint.transform.position) < maxDistanceSq)
                transform.position = targetPos;
        }

    }
}
