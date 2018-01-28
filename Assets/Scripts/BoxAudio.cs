using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudio : MonoBehaviour {

    public AudioSource[] fallAudio;

    public void PlaySound()
    {
        int randIdx = Random.Range(0, fallAudio.Length);
        fallAudio[randIdx].Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlaySound();
    }

}
