using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSkip : MonoBehaviour
{

    [SerializeField] private Button ButtonSkip01;
    public GameObject storyBoard1;
    public GameObject storyBoard2;

    private void Awake()
    {
        ButtonSkip01.onClick.AddListener(OnButtonSkipClick);
    }

    private void OnButtonSkipClick()
    {
        if (storyBoard1.activeSelf)
        {
            storyBoard1.SetActive(false);
            storyBoard2.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("Cortar");
        }
    }
}