using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Define a instancia (que é ele mesmo)

    [Header("Buttons")]
    //Timer
    [Min(10f)]public float MaxTime; // Tempo de espera para liberar o skip
    private float _Timer; // Contador do tempo

    [Header("Inventory")]

    //score
    [SerializeField]private TMP_Text ScoreText; // Decide o texto usado para contar na tela a quantidade de pontos Score;
    [SerializeField]private Button FishButton; // Decide o texto usado para contar na tela a quantidade de pontos Score;
    [SerializeField]private Button MeatButton; // Decide o texto usado para contar na tela a quantidade de pontos Score;
    [SerializeField]private Button AbacaxiButton; // Decide o texto usado para contar na tela a quantidade de pontos Score;
    [SerializeField]private Button TomateButton; // Decide o texto usado para contar na tela a quantidade de pontos Score;

    [Header("Minigames")]
    [SerializeField] public GameObject cortar; // "Cena" Cortar
    private bool OnCortar = true;
    [SerializeField] public GameObject cozinhar; // "Cena" Cozinhar
    private bool OnCozinhar = false;

    public bool ChangedScene = false; // Cena trocou?

    public GameObject unbreakable;
    public float unBreakTime = 3f; // Tempo de espera
    private float _unBreakTimer; // Contador do tempo

    public bool OnBreak = false; // Estado de quebrado (faca)
    //ParticleSystem ps;
    public TrailRenderer Trail;

    [Header("Inventory")]
    // invent�rio
    public Dictionary<Alimentos.ItemType, int> inventory =
        new Dictionary<Alimentos.ItemType, int>();
    public TextMeshProUGUI fishCount;
    public TextMeshProUGUI meatCount;
    public TextMeshProUGUI abacaxiCount;
    public TextMeshProUGUI tomateCount;
    public TextMeshProUGUI farinhaCount;



    public int TotalFails = 0;

    private void Awake()
    {
        Instance = this;

        // Inicializa todos alimentos com 0
        foreach (Alimentos.ItemType item in
                 System.Enum.GetValues(typeof(Alimentos.ItemType)))
        {
            inventory[item] = 0;
        }
    }

    public void Update()
    {
        _Timer += Time.deltaTime; // Contador de tempo

        if (OnBreak == true)
        {
            Trail.GetComponent<MouseTrail>().onBreak = true;
            _unBreakTimer += Time.deltaTime; //botar dentro da fuñçao
        }

        if (_unBreakTimer >= unBreakTime) // O tempo ja passou o suficiente?
        {
            OnBreak = false;
            Trail.GetComponent<MouseTrail>().onBreak = false;
            _unBreakTimer = 0f;
            unbreakable.SetActive(OnBreak);
        }

        if (TotalFails >= 3)
        {
            TotalFails = 0;
            GameManager.Instance.NoBreak();
            TransitionsFade.Instance.CallCoroutine_LoadOtherGameSection();
            Debug.Log(TotalFails);

        }
    }

    public void NoBreak()
    {
        OnBreak = true;
        unbreakable.SetActive(OnBreak);
    }

    public void ChangeScene()
    {
        TotalFails = 0;

        if (GameObject.FindWithTag("Spawner") != null)
        {
            GameObject.FindWithTag("Spawner").GetComponent<Spawner>().DeleteChildrens(); // Chama o evento que limpa os filhos do spawner
            GameObject.FindWithTag("Spawner").GetComponent<Spawner>().SpawnTime = 5f;
            GameObject.FindWithTag("Spawner").GetComponent<Spawner>().CutTime = 35f;
        }

        OnCortar = !OnCortar;
        cortar.SetActive(OnCortar);
        OnCozinhar = !OnCozinhar;
        cozinhar.SetActive(OnCozinhar);
        UpdateItemCount();
    }
    public void UpdateItemCount() // Atualiza a qantidade de itens no inventario
    {
        fishCount.text = inventory[Alimentos.ItemType.Peixe].ToString();
        meatCount.text = inventory[Alimentos.ItemType.Carne].ToString();
        abacaxiCount.text = inventory[Alimentos.ItemType.Abacaxi].ToString();
        tomateCount.text = inventory[Alimentos.ItemType.Tomate].ToString();
        farinhaCount.text = inventory[Alimentos.ItemType.Farinha].ToString();
    }

    public void AddItem(Alimentos.ItemType type) // Adicionador de item
    {
        inventory[type]++; // Adiciona 1 
        ScoreText.text = type + ": " + inventory[type]; // Adiciona ao tipo
        Debug.Log(type + ": " + inventory[type]); // Printa qual foi o tipo adicionado
    }

    public void SubtractItem(Alimentos.ItemType type) // Adicionador de item
    {
        if (type > 0)
        {
            inventory[type]--; // Adiciona 1 
        }
        ScoreText.text = type + ": " + inventory[type]; // Adiciona ao tipo
        Debug.Log(type + ": " + inventory[type]); // Printa qual foi o tipo adicionado
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