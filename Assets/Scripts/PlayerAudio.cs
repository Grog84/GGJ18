using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioSource[] painAudio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int audioIdx = Random.Range(0, painAudio.Length);
        painAudio[audioIdx].Play();
    }

}
