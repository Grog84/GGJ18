using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public Image fadeEffect;
    public GameObject menuFinished;
    public Animator menuAnimator;
    public AudioSource menusource;
    public AudioSource buttonsource;
    public AudioSource cricetsource;


    private void Awake()
    {
        menuAnimator.speed = 0;
    }

    // Use this for initialization
    void Start() {

        fadeEffect.DOFade(0f, 3f);
        menusource.DOFade(0.35f, 6f);
        StartCoroutine(StartAnimationCO());
    }

    IEnumerator StartAnimationCO()
    {
        yield return new WaitForSecondsRealtime(5f);
        menuAnimator.speed = 1;
    }

    public void StartFinalAnimation()
    {
        buttonsource.PlayOneShot(buttonsource.clip);
        menuAnimator.SetBool("finish", true);

        menuFinished.transform.position = new Vector3(menuFinished.transform.position.x, menuFinished.transform.position.y, -1.5f);
        StartCoroutine(WaitFinish());
    }

    IEnumerator WaitFinish()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        cricetsource.PlayOneShot(cricetsource.clip);
        yield return new WaitForSecondsRealtime(3f);
        FadeOut();
    }

    public void FadeOut()
    {
        fadeEffect.DOFade(1f, 3f);
        menusource.DOFade(0f, 2f);
        StartCoroutine(FadeOutCO());
    }

    IEnumerator FadeOutCO()
    {
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(1);
    }

}
