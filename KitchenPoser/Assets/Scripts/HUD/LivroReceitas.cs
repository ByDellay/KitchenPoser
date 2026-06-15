using UnityEngine;
using UnityEngine.SceneManagement;

public class LivroReceitas : MonoBehaviour
{
    public GameObject CookBookClose;
    public GameObject CookBookOpen;
    public GameObject ButtonOpen;
    public GameObject ButtonClose;


    private void BookClickState()
    {
        if (CookBookClose.activeSelf)
        {
            CookBookClose.SetActive(false);
            CookBookOpen.SetActive(true);

        }


    }





    /*private void OnButtonSkipClick()
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
    } */





}
