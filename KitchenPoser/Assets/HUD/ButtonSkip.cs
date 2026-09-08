using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSkip : MonoBehaviour
{
    [SerializeField] private AudioClip ClickSFX;

    [SerializeField] private Button ButtonSkip01; //Botão que pula pro proximo
    public GameObject storyBoard1; // Pagina 1
    public GameObject storyBoard2; // Pagina 2
    public GameObject storyBoard3;
    public GameObject storyBoard4;

    private void Awake()
    {
        ButtonSkip01.onClick.AddListener(OnButtonSkipClick); // Adiciona o ouvinte
    }

    private void OnButtonSkipClick()
    {
        AudioManager.Instance.AudioPlaySFX(ClickSFX, transform, 1f);

        if (storyBoard1.activeSelf) // Se estiver na primeira pagina
        {
            storyBoard1.SetActive(false); // Vai pra proxima
            storyBoard2.SetActive(true); // Proxima
        }
        else if (storyBoard2.activeSelf)
        {
            storyBoard2.SetActive(false); // Vai pra proxima
            storyBoard3.SetActive(true); // Proxima
        }
        else if (storyBoard3.activeSelf)
        {
            storyBoard3.SetActive(false); // Vai pra proxima
            storyBoard4.SetActive(true); // Proxima
        }
        else
        {
            SceneManager.LoadScene("Game"); // Começa o jogo
        }
    }
}