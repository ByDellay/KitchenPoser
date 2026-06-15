using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivroReceitas : MonoBehaviour
{
    public GameObject fundoEscuro;
    public GameObject CookBookClose;
    public GameObject CookBookOpen;
    public GameObject ButtonOpen;
    public GameObject ButtonClose;

    //public string[] bookPage = { 0, 1, 2, 3 };

    public GameObject pageChangeLeft;
    public GameObject pageChangeRight;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;



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


    public void PageChangeRight()
    {
        if (page1.activeSelf)
        {
            Debug.Log("mudou pagina");
            page1.SetActive(false);
            page2.SetActive(true);
        }
        else if(page2.activeSelf) 
        {
            Debug.Log("mudou pagina");
            page2.SetActive(false);
            page3.SetActive(true);
        }
    }
    public void PageChangeLeft()
    {
        if (page3.activeSelf)
        {
            page3.SetActive(false);
            page2.SetActive(true);
        }
        else if (page2.activeSelf)
        {
            page2.SetActive(false);
            page1.SetActive(true);
        }
    }
    public void Update()
    {
        if (page1.activeSelf)
        {
            pageChangeLeft.SetActive(false);
        }
        else if (page3.activeSelf)
        {
            pageChangeRight.SetActive(false);
        }
        else
        {
            pageChangeLeft.SetActive(true);
            pageChangeRight.SetActive(true);
        }
    }




    

    /*public switch BookPage
    {
    case 1 
    exibir aprimeira pagina
    desativar todas as outras
    break

    case 2

    }*/





}
