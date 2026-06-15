using UnityEngine;
using UnityEngine.SceneManagement;

public class LivroReceitas : MonoBehaviour
{
    public GameObject fundoEscuro;
    public GameObject CookBookClose;
    public GameObject CookBookOpen;
    public GameObject ButtonOpen;
    public GameObject ButtonClose;


    public void BookStateClick()
    {
        if (CookBookClose.activeSelf)
        {
            Debug.Log("clicou no livro");
            CookBookClose.SetActive(false);
            CookBookOpen.SetActive(true);
            fundoEscuro.SetActive(true);
        }
        else
        {
            Debug.Log("desativou o livro");
            CookBookClose.SetActive(true);
            CookBookOpen.SetActive(false);
            fundoEscuro.SetActive(false);
        }
    }



}
