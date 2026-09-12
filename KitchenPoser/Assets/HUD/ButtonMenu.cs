using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] GameObject Creditos;
    [SerializeField] GameObject Menu;
    [SerializeField] private AudioClip ClickSFX;

    //int FadeTime = 1;
    //public Animator CrossFade;
    public void OnButtonPlayClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);

        TransitionsFade.Instance.CallCoroutine_LoadNewScene("StoryBoard");
        //SceneManager.LoadScene("StoryBoard");
    }
    public void OnButtonCreditClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);
        Debug.Log("Abrindo os creditos");
        Creditos.SetActive(true);
        Menu.SetActive(false);
    }
    public void OnButtonCreditCloseClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);
        Debug.Log("Fechando os creditos");
        Creditos.SetActive(false);
        Menu.SetActive(true);
    }

    public void OnButtonQuitClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);
        Application.Quit();
    }
}
