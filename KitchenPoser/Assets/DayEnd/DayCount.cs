using TMPro;
using UnityEngine;

public class DayCount : MonoBehaviour
{
    public static DayCount Instance;
    [Header("cenas")]
    public GameObject cortar;
    public GameObject cozinhar;
    public GameObject dayEnd;
    public GameObject final;

    [Header("variaveis")]
    public int day;
    public int alimentosCount;
    public int receitasCount;
    public int receitasCountFinal;

    [Header("UI")]
    // mostrar na tela a quantidade de alimentos coletados
    public TextMeshProUGUI alimentosColetados;
    public TextMeshProUGUI receitasFeitas;
    public TextMeshProUGUI faltamDias;

    [Header("scripts")]
    public GameObject gameManager;
    public GameObject spawner;

    [Header("final")]
    public TextMeshProUGUI receitasCozinhadasFinal;
    public TextMeshProUGUI scoreFinal;

    public void Start()
    {
        Instance = this;
        alimentosColetados.text = alimentosCount.ToString();
        receitasFeitas.text = receitasCount.ToString();
        day = 2;
    }

    public void encerrarCozinhar()
    {  
        cozinhar.SetActive(false);
        dayEnd.SetActive(true);
        alimentosColetados.text = alimentosCount.ToString();
        receitasFeitas.text = receitasCount.ToString();
        
        //perdao eu tava com muita preguiça pra pensar entao fiz desse jeito mesmo
        if (day == 2)
        {
            faltamDias.text = "Faltam 2 dias para a entrevista...";
        }
        else if (day == 1)
        {
            faltamDias.text = "Falta 1 dia para a entrevista...";
        }
        else
        {
            faltamDias.text = "O dia da entrevista chegou.";
        }
    }

    public void encerrarDia()
    {

        // spawner.GetComponent<Spawner>().DeleteChildrens(); nao funciona pq os filhos estao desativados e essa funçao so pega quando ta ativado
        spawner.GetComponent<Spawner>().ReiniciarCiclo();

        gameManager.GetComponent<GameManager>().TotalFails = 0;
        GameManager.Instance.CurrentRecipeObject.SetActive(false);




        if (day <= 0)
        {
            dayEnd.SetActive(false);
            final.SetActive(true);

            receitasCozinhadasFinal.text = $"total de receitas cozinhadas: {receitasCountFinal.ToString()}";
            if (receitasCountFinal <= 1) //botar mais aqui
            {
                scoreFinal.text = "seu desempenho foi terrivel";
            }
            else if (receitasCountFinal == 2)
            {
                scoreFinal.text = "seu desempenho foi mediano";
            }
            else if (receitasCountFinal == 3)
            {
                scoreFinal.text = "seu desempenho foi bom";

            }
            else if(receitasCountFinal >= 4)
            {
             scoreFinal.text = "seu desempenho foi perfeito";

            }

        }
        else
        {
            alimentosCount = 0;
            receitasCount = 0;
            day--;
            dayEnd.SetActive(false);

            gameManager.GetComponent<GameManager>()
                .IniciarCicloDeCorte();
            Debug.Log("ENCERROU O DIA");
            Debug.Log(day);
        }
    }
}
// TransitionsFade.Instance.CallCoroutine_LoadOtherGameSection(); <- trocar de cena (nao da pra chamar corrotina, só função publica)