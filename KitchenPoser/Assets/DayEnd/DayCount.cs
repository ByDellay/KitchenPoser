using UnityEngine;

public class DayCount : MonoBehaviour
{
    public GameObject cortar;
    public GameObject cozinhar;
    public GameObject dayEnd;

    public int day;

    public int alimentosCount;
    // mostrar na tela a quantidade de alimentos coletados

    void Start()
    {
        
    }

    public void encerrarCozinhar()
    {  
        cozinhar.SetActive(false);
        dayEnd.SetActive(true);
    }

    public void encerrarDia()
    {
        dayEnd.SetActive(false);
        cortar.SetActive(true);
        Debug.Log("clicou");
    }

    void Update()
    {
        
    }
}
// TransitionsFade.Instance.CallCoroutine_LoadOtherGameSection(); <- trocar de cena