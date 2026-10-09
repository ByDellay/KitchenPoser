using TMPro;
using UnityEngine;

public class DayCount : MonoBehaviour
{
    public GameObject cortar;
    public GameObject cozinhar;
    public GameObject dayEnd;

    public int day;

    public int alimentosCount;
    public int receitasCount;
    // mostrar na tela a quantidade de alimentos coletados
    public TextMeshProUGUI alimentosColetados;
    public TextMeshProUGUI receitasFeitas;

    public void Start()
    {
        alimentosColetados.text = alimentosCount.ToString();
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
        dayEnd.SetActive(false);
        cortar.SetActive(true);
        Debug.Log("clicou");
    }
}
// TransitionsFade.Instance.CallCoroutine_LoadOtherGameSection(); <- trocar de cena