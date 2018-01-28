using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioScript : MonoBehaviour
{
    public AudioSource ambientSource;
    public AudioSource introSource;
    public AudioSource musicLoopSource;
        

    void Start()
    {
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(15);
        introSource.PlayOneShot(introSource.clip);
        introSource.DOFade(0.5f, 10f);
        
        yield return new WaitForSeconds(24.3f);
        musicLoopSource.Play();
    }
}
