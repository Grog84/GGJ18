using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Chronos;

public class CameraController : MonoBehaviour {

    public Transform[] fixedPositions;
    int currentAreaIdx = 0;
    //public LocalClock[] localClocks;
    Vector3 nextPosition;

    bool isLerping = false;

    private void Start()
    {
        nextPosition = new Vector3(fixedPositions[currentAreaIdx].position.x, fixedPositions[currentAreaIdx].position.y, -10f);
        transform.DOMove(nextPosition, 2f);
        //localClocks = FindObjectsOfType<LocalClock>();
    }

    public void MoveToArea(int idx)
    {
        if (idx != currentAreaIdx)
        {
            isLerping = true;
            currentAreaIdx = idx;
            nextPosition = new Vector3(fixedPositions[currentAreaIdx].position.x, fixedPositions[currentAreaIdx].position.y, -10f);
            transform.DOMove(nextPosition, 2f);
        }
    }

    //private void Update()
    //{
    //    if (isLerping)
    //    {
    //        foreach (var clock in localClocks)
    //        {
    //            clock.paused = true;
    //        }

    //        if (Vector3.Distance(transform.position, nextPosition) < 0.1)
    //        {
    //            isLerping = false;
    //            foreach (var clock in localClocks)
    //            {
    //                clock.paused = false;
    //            }
    //        }
    //    }

    //}

}
