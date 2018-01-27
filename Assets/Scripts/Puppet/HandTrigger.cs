using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    public GrabSystem grabSystem;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        grabSystem.SetAtReach(gameObject, transform);
    }
}
