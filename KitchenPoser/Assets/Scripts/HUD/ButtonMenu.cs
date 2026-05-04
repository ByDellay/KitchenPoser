using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour
{

    [SerializeField]private Button ButtonPlay;
    [SerializeField]private Button ButtonQuit;

    private void Awake()
    {
        ButtonPlay.onClick.AddListener(OnButtonPlayClick);
        ButtonQuit.onClick.AddListener(OnButtonQuitClick);
    }

    private void OnButtonPlayClick()
    {
        SceneManager.LoadScene("StoryBoard");
    }
    private void OnButtonQuitClick()
    {
        Debug.Log("Fechando o jogo..."); // Apenas para testar no editor
        Application.Quit(); // Fecha o executável buildado, não da pra ver direto da unity, mas se voce buildar o executavel >provavelmente funciona<
    }
}
