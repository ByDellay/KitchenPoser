using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonMenu : MonoBehaviour
{
    [Header("Bot�es")]
    [SerializeField]private Button ButtonPlay;
    [SerializeField]private Button ButtonCredit;
    [SerializeField]private Button ButtonCreditClose;
    [SerializeField]private Button ButtonQuit;

    [Header("outro")]
    [SerializeField] GameObject Creditos;
    [SerializeField] private AudioClip ClickSFX;

    //int FadeTime = 1;
    //public Animator CrossFade;

    private void Awake()
    {
        ButtonPlay.onClick.AddListener(OnButtonPlayClick);
        ButtonCredit.onClick.AddListener(OnButtonCreditClick);
        ButtonCreditClose.onClick.AddListener(OnButtonCreditCloseClick);
        ButtonQuit.onClick.AddListener(OnButtonQuitClick);
    }

    private void OnButtonPlayClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);

        TransitionsFade.Instance.CallCoroutine_LoadNewScene("StoryBoard");
        //SceneManager.LoadScene("StoryBoard");
    }
    private void OnButtonCreditClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);
        Debug.Log("Abrindo os creditos");
        Creditos.SetActive(true);
        ButtonCreditClose.gameObject.SetActive(true);

        ButtonPlay.gameObject.SetActive(false);
        ButtonCredit.gameObject.SetActive(false);
        ButtonQuit.gameObject.SetActive(false);
    }
    private void OnButtonCreditCloseClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);
        Debug.Log("Fechando os creditos");
        Creditos.SetActive(false);
        ButtonCreditClose.gameObject.SetActive(false);

        ButtonPlay.gameObject.SetActive(true);
        ButtonCredit.gameObject.SetActive(true);
        ButtonQuit.gameObject.SetActive(true);
    }

    private void OnButtonQuitClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f, 1f);
        Application.Quit(); // Fecha o execut�vel buildado, n�o da pra ver direto da unity, mas se voce buildar o executavel >provavelmente funciona<
    }

    /*IEnumerator LoadNewScene(string Scene)
    {
        CrossFade.SetTrigger("Start");

        yield return new WaitForSeconds(FadeTime);

        SceneManager.LoadScene(Scene);
    }*/
}
