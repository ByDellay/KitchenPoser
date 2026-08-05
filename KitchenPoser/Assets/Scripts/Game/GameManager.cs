using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Buttons")]
    //Timer
    [Min(10f)]public float MaxTime; // Tempo de espera entre cada spawner
    private float _Timer; // Contador do tempo
    public GameObject SkipScene;

    [Header("Inventory")]

    //score
    [SerializeField]private TMP_Text ScoreText; //Decide o texto usado para contar na tela a quantidade de pontos Score;

    [Header("Minigames")]
    [SerializeField] public GameObject cortar;
    [SerializeField] public GameObject cozinhar;
    

    // invent�rio
    public Dictionary<Alimentos.ItemType, int> inventory =
        new Dictionary<Alimentos.ItemType, int>();

    public void OnSkipTemp()
    {
        cortar.SetActive(false);
        cozinhar.SetActive(true);
    }
   

    private void Awake()
    {
        Instance = this;
        // inicializa todos alimentos com 0
        foreach (Alimentos.ItemType item in
                 System.Enum.GetValues(typeof(Alimentos.ItemType)))
        {
            inventory[item] = 0;
        }
    }

    public void Update()
    {
        _Timer += Time.deltaTime; // Contador de tempo

        if (_Timer >= MaxTime) // O tempo ja passou o suficiente?
        {
           SkipScene.SetActive(true); 
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