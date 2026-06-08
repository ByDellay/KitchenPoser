using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //score
    [SerializeField]private TMP_Text ScoreText; //Decide o texto usado para contar na tela a quantidade de pontos Score;

    // invent�rio
    public Dictionary<Alimentos.ItemType, int> inventory =
        new Dictionary<Alimentos.ItemType, int>();

    public GameObject storyBoard1;
    public GameObject storyBoard2;

   /* public void SkipStory()
    {
        if(storyBoard1==true)
        {
            storyBoard1 = storyBoard1.activeSelf(false);
            storyBoard2 = true;
        }
        else if (storyBoard2 != null) 
        {
            storyBoard2 = null;
            SceneManager.LoadScene("Cortar");
        }
    }   */

    private void Awake()
    {


        // singleton
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // inicializa todos alimentos com 0
        foreach (Alimentos.ItemType item in
                 System.Enum.GetValues(typeof(Alimentos.ItemType)))
        {
            inventory[item] = 0;
        }
    }

    public void AddItem(Alimentos.ItemType type)
    {
        inventory[type]++;
        ScoreText.text = type + ": " + inventory[type];
        Debug.Log(type + ": " + inventory[type]);
    }

    public int GetItemCount(Alimentos.ItemType type)
    {
        return inventory[type];
    }

    // evento para abrir o menu, tem que fazer ainda, por favor faz acabar eu quero morrer
    /*public void AbriuMenu()
    {
        {
            print("abriu");
            .Invoke();
        }
    }*/
}