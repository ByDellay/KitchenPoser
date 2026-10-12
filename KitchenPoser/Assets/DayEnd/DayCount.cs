using TMPro;
using UnityEngine;

public class DayCount : MonoBehaviour
{
    [Header("cenas")]
    public GameObject cortar;
    public GameObject cozinhar;
    public GameObject dayEnd;

    [Header("variaveis")]
    public int day;
    public int alimentosCount;
    public int receitasCount;

    [Header("UI")]
    // mostrar na tela a quantidade de alimentos coletados
    public TextMeshProUGUI alimentosColetados;
    public TextMeshProUGUI receitasFeitas;

    [Header("scripts")]
    public GameObject gameManager;
    public GameObject spawner;

    public void Start()
    {
        alimentosColetados.text = alimentosCount.ToString();
        receitasFeitas.text = receitasCount.ToString();
    }
    public void encerrarCozinhar()
    {  
        cozinhar.SetActive(false);
        dayEnd.SetActive(true);
        alimentosColetados.text = alimentosCount.ToString();
        receitasFeitas.text = receitasCount.ToString();
    }

    public void encerrarDia()
    {
        
        // spawner.GetComponent<Spawner>().DeleteChildrens(); nao funciona pq os filhos estao desativados e essa funçao so pega quando ta ativado
        spawner.GetComponent<Spawner>().CutTime = 60;
        spawner.GetComponent<Spawner>().CutTimer = 0;
        spawner.GetComponent<Spawner>()._CutTimerText = 60;
        spawner.GetComponent<Spawner>().Acabou = false;

        gameManager.GetComponent<GameManager>().TotalFails = 0;

        day++;
        dayEnd.SetActive(false);
        cortar.SetActive(true);
        Debug.Log("ENCERROU O DIA");
        Debug.Log(day);
    }
}
// TransitionsFade.Instance.CallCoroutine_LoadOtherGameSection(); <- trocar de cena