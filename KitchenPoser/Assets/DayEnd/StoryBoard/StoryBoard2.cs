using UnityEngine;

public class StoryBoard2 : MonoBehaviour
{
    [Header("outro")]
    public GameObject revelacao;
    public GameObject storyBoard;
    public GameObject finalFIM;

    [Header("fim do mundo")]
    public GameObject fimEnding;
    public GameObject fimEnding2;
    public GameObject fimEnding3;

    [Header("bad ending")]
    public GameObject badEnding;
    public GameObject badEnding2;
    public GameObject badEnding3;

    [Header("good ending")]
    public GameObject goodEnding;
    public GameObject goodEnding2;
    public GameObject goodEnding3;

    [Header("perfect ending")]
    public GameObject perfectEnding;
    public GameObject perfectEnding2;
    public GameObject perfectEnding3;

    [Header("scripts")]
    public DayCount dayCount;
    private bool acabouDeVez;
    private bool fim, bad, good, perfect;

    private void Start()
    {
        fim = false;
        bad = false;
        good = false;
        perfect = false;
        acabouDeVez = false;
        FinalStoryBoard(); //temp
    }

    public void FinalStoryBoard()
    {
        // dayCountScript = dayCount.GetComponent<GameObject>();
        if (dayCount.receitasCountFinal <= 3) // ativa o final terrivel
        {
            fimEnding.SetActive(true);
            fim = true;
        }
        else if (dayCount.receitasCountFinal <= 6) // final ruim
        {
            badEnding.SetActive(true);
            bad = true;
        }
        else if (dayCount.receitasCountFinal <= 9) // final bom
        {
            goodEnding.SetActive(true);
            good = true;
        }
        else if (dayCount.receitasCountFinal >= 11) // final perfeito
        {
            perfectEnding.SetActive(true);
            perfect = true;
        }
    }
    
    public void NextPanel()
    {
        Debug.Log("foi");
        if (revelacao.activeSelf == false)
        {
            revelacao.SetActive(true);
        }
        else
        {
            if (fim)
            {
                if (fimEnding2.activeSelf == false)
                {
                    fimEnding2.SetActive(true);
                }
                else if (fimEnding3.activeSelf == false)
                {
                    fimEnding3.SetActive(true);
                }
                else
                {
                    acabouDeVez = true;
                }
            }

            else if (bad)
            {
                if (badEnding2.activeSelf == false)
                {
                    badEnding2.SetActive(true);
                }
                else if (badEnding3.activeSelf == false)
                {
                    badEnding3.SetActive(true);
                }
                else
                {
                    acabouDeVez = true;
                }
            }

            else if (good)
            {
                if (goodEnding2.activeSelf == false)
                {
                    goodEnding2.SetActive(true);
                }
                else if (goodEnding3.activeSelf == false)
                {
                    goodEnding3.SetActive(true);
                }
                else
                {
                    acabouDeVez = true;
                }
            }
            if (perfect)
            {
                if (perfectEnding2.activeSelf == false)
                {
                    perfectEnding2.SetActive(true);
                }
                else if (perfectEnding3.activeSelf == false)
                {
                    perfectEnding3.SetActive(true);
                }
                else
                {
                    acabouDeVez = true;
                }
            }

        }
     
        if (acabouDeVez == true) //encerra o jogo pra sempre pra valer
        {
            dayCount.Resultado();
            finalFIM.SetActive(true);
            storyBoard.SetActive(false);
        }
        
    }



}
