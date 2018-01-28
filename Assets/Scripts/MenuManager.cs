using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Image fadeEffect;
    public Animator menuAnimator;

    private void Awake()
    {
        menuAnimator.speed = 0;
    }

    // Use this for initialization
    void Start() {

        fadeEffect.DOFade(0f, 3f);
        StartCoroutine(StartAnimationCO());
    }

    IEnumerator StartAnimationCO()
    {
        yield return new WaitForSecondsRealtime(5f);
        StartFinalAnimation();
    }

    public void StartFinalAnimation()
    {
        menuAnimator.speed = 1f;
    }

    public void FadeOut()
    {
        fadeEffect.DOFade(1f, 3f);
        StartCoroutine(FadeOutCO());
    }

    IEnumerator FadeOutCO()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(1);
    }

}
