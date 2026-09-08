using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject fundoEscuro;
    public GameObject CookBookClose;
    public GameObject CookBookOpen;

    [Header("Buttons")]
    public GameObject pageChangeLeft;
    public GameObject pageChangeRight;

    [Header("Pages")]
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    [Header("Favorite")]
    public GameObject FavoriteButton;
    public GameObject receita1Fav;
    public GameObject receita2Fav;
    public GameObject receita3Fav;



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

    public GameObject arm1Inventario;
    public GameObject arm1Outventario;
    public GameObject arm2Inventario;


    public void OnArmario1()
    {
        arm1Inventario.SetActive(true);
        arm1Outventario.SetActive(true);
        GameManager.Instance.UpdateItemCount();
    }
    public void OutArmario1()
    {
        arm1Inventario.SetActive(false);
        arm1Outventario.SetActive(false);
        arm2Inventario.SetActive(false);
    }
    public void OnArmario2()
    {
        arm2Inventario.SetActive(true);
        arm1Outventario.SetActive(true);
    }


    public void OnFavorite()
    {


    }


}
