using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IKTarget : MonoBehaviour {

    public GrabRadar radar;
    public GrabSystem m_grabSystem;
    Vector3 startingPosition;

    private void Start()
    {
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update() {

        if (radar.nearestGrabbleObject != null)
        {
            transform.DOMove(radar.nearestGrabbleObject.transform.position, 0.5f);
        }

        //else if (m_grabSystem.isGrabbing == false)
        //{

        //}

        else
        {
            transform.DOLocalMove(startingPosition, 0.5f);
            //transform.localPosition = startingPosition;
        }

	}

    
}
