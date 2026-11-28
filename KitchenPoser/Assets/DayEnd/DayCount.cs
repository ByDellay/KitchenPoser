using TMPro;
using UnityEngine;

public class DayCount : MonoBehaviour
{
    public static DayCount Instance;
    [Header("cenas")]
    public GameObject cortar;
    public GameObject cozinhar;
    public GameObject dayEnd;
    public GameObject storyBoard2;
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
            // fazer transição maravilhosa aqui dellai por favor nao quero aprender corrotina perdao
            dayEnd.SetActive(false);
            storyBoard2.SetActive(true);

            

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

    public void Resultado()
    {
        receitasCozinhadasFinal.text = $"receitas cozinhadas: {receitasCountFinal.ToString()}";
        if (receitasCountFinal <= 3)
        {
            scoreFinal.text = "Final FIM DO MUNDO feito";
        }
        else if (receitasCountFinal == 6)
        {
            scoreFinal.text = "Final ruim feito";
        }
        else if (receitasCountFinal == 9)
        {
            scoreFinal.text = "Final bom feito";

        }
        else if (receitasCountFinal >= 11)
        {
            scoreFinal.text = "Final UTOPIA feito";

        }
    }
}
// TransitionsFade.Instance.CallCoroutine_LoadOtherGameSection(); <- trocar de cena (nao da pra chamar corrotina, só função publica)