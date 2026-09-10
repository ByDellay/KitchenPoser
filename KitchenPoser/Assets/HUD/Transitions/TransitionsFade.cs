using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransitionsFade : MonoBehaviour
{
    public static TransitionsFade Instance;
    int FadeTime = 2;
    public Animator CrossFade;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        //CrossFade.SetBool("GoFadeIn", true);
    }

    public void CallCoroutine_LoadNewScene(string Scene)
    {
        StartCoroutine(LoadNewScene(Scene));
    }

    public void CallCoroutine_LoadOtherGameSection()
    {
        StartCoroutine(LoadOtherGameSection());
    }

    public IEnumerator LoadNewScene(string Scene)
    {
        CrossFade.SetTrigger("Start");
        
        yield return new WaitForSeconds(FadeTime);

        SceneManager.LoadScene(Scene);
    }

    public IEnumerator LoadOtherGameSection()
    {
        CrossFade.SetTrigger("Start");
        CrossFade.SetBool("GoFadeIn", false);

        yield return new WaitForSeconds(FadeTime);

        CrossFade.SetBool("GoFadeIn", true);
        GameManager.Instance.ChangeScene(); // Troca de cena    
    }
}
