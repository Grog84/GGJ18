using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour {

    public AudioSource[] complainsAudio;

    public void OnGrab()
    {
        int idx = Random.Range(0, complainsAudio.Length);
        complainsAudio[idx].Play();
    }
	
}
