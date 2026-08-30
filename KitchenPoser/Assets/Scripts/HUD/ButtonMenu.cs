using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    [Header("Bot�es")]
    [SerializeField]private Button ButtonPlay;
    [SerializeField]private Button ButtonCredit;
    [SerializeField]private Button ButtonCreditClose;
    [SerializeField]private Button ButtonQuit;

    [Header("outro")]
    [SerializeField] GameObject Creditos;
    public AudioClip ClickSFX;
    public AudioSource AudioSource;


    public void PlaySound()
    {
        AudioSource.PlayOneShot(ClickSFX);
    }

    private void Awake()
    {
        ButtonPlay.onClick.AddListener(OnButtonPlayClick);
        ButtonCredit.onClick.AddListener(OnButtonCreditClick);
        ButtonCreditClose.onClick.AddListener(OnButtonCreditCloseClick);
        ButtonQuit.onClick.AddListener(OnButtonQuitClick);
    }

    private void OnButtonPlayClick()
    {
        AudioSource.PlayOneShot(ClickSFX);
        SceneManager.LoadScene("StoryBoard");
    }
    private void OnButtonCreditClick()
    {
        AudioSource.PlayOneShot(ClickSFX);
        Debug.Log("Abrindo os creditos");
        Creditos.SetActive(true);
        ButtonCreditClose.gameObject.SetActive(true);

        ButtonPlay.gameObject.SetActive(false);
        ButtonCredit.gameObject.SetActive(false);
        ButtonQuit.gameObject.SetActive(false);
    }
    private void OnButtonCreditCloseClick()
    {
        AudioSource.PlayOneShot(ClickSFX);
        Debug.Log("Fechando os creditos");
        Creditos.SetActive(false);
        ButtonCreditClose.gameObject.SetActive(false);

        ButtonPlay.gameObject.SetActive(true);
        ButtonCredit.gameObject.SetActive(true);
        ButtonQuit.gameObject.SetActive(true);
    }

    private void OnButtonQuitClick()
    {
        AudioSource.PlayOneShot(ClickSFX);
        Application.Quit(); // Fecha o execut�vel buildado, n�o da pra ver direto da unity, mas se voce buildar o executavel >provavelmente funciona<
    }
}
