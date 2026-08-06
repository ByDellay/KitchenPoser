using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{
    [Header("Botões")]
    [SerializeField]private Button ButtonPlay;
    [SerializeField]private Button ButtonCredit;
    [SerializeField]private Button ButtonCreditClose;
    [SerializeField]private Button ButtonQuit;

    [Header("outro")]
    [SerializeField] GameObject Creditos;

    private void Awake()
    {
        ButtonPlay.onClick.AddListener(OnButtonPlayClick);
        ButtonCredit.onClick.AddListener(OnButtonCreditClick);
        ButtonCreditClose.onClick.AddListener(OnButtonCreditCloseClick);
        ButtonQuit.onClick.AddListener(OnButtonQuitClick);
    }

    private void OnButtonPlayClick()
    {
        SceneManager.LoadScene("StoryBoard");
    }
    private void OnButtonCreditClick()
    {
        Debug.Log("Abrindo os creditos");
        Creditos.SetActive(true);
        ButtonCreditClose.gameObject.SetActive(true);

        ButtonPlay.gameObject.SetActive(false);
        ButtonCredit.gameObject.SetActive(false);
        ButtonQuit.gameObject.SetActive(false);
    }
    private void OnButtonCreditCloseClick()
    {
        Debug.Log("Fechando os creditos");
        Creditos.SetActive(false);
        ButtonCreditClose.gameObject.SetActive(false);

        ButtonPlay.gameObject.SetActive(true);
        ButtonCredit.gameObject.SetActive(true);
        ButtonQuit.gameObject.SetActive(true);
    }

    private void OnButtonQuitClick()
    {
        Debug.Log("Fechando o jogo..."); // Apenas para testar no editor
        Application.Quit(); // Fecha o executável buildado, não da pra ver direto da unity, mas se voce buildar o executavel >provavelmente funciona<
    }
}
