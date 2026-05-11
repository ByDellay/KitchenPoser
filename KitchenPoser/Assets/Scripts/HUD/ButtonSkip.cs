using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSkip : MonoBehaviour
{

    [SerializeField] private Button ButtonSkip01;


    private void Awake()
    {
        ButtonSkip01.onClick.AddListener(OnButtonSkipClick);
    }

    private void OnButtonSkipClick()
    {
        SceneManager.LoadScene("Cortar");
    }
}