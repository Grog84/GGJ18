﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrigger : MonoBehaviour
{
    public GrabSystem grabSystem;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            Debug.Log("I can grab!");
            grabSystem.SetAtReach(gameObject, transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabbleObject")
        {
            Debug.Log("Oh no....!");
            grabSystem.SetNomoreAtReach();
        }
    }
}
