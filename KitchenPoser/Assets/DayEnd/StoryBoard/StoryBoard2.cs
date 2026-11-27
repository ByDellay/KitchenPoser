using UnityEngine;

public class StoryBoard2 : MonoBehaviour
{
    public GameObject revelacao;


    public GameObject fimEnding;
    public GameObject fimEnding2;
    public GameObject fimEnding3;
    
    public GameObject badEnding;
    public GameObject badEnding2;
    public GameObject badEnding3;
    
    public GameObject goodEnding;
    public GameObject goodEnding2;
    public GameObject goodEnding3;

    public GameObject perfectEnding;
    public GameObject perfectEnding2;
    public GameObject perfectEnding3;

    public DayCount dayCount;


    private bool fim, bad, good, perfect;

    private void Start()
    {
        fim = false;
        bad = false;
        good = false;
        perfect = false;
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
        else if (dayCount.receitasCountFinal >= 10) // final perfeito
        {
            perfectEnding.SetActive(true);
            perfect = true;
        }
    }
    
    public void NextPanel()
    {
        if (fim)
        {
            if (revelacao == false)
            {
                revelacao.SetActive(true);

            }
            else if (fimEnding2 == false)
            {
                fimEnding2.SetActive(true);
            }
            else if (fimEnding3 == false)
            {
                fimEnding3.SetActive(true);
            }
        }

        if (bad)
        {
            if (revelacao == false)
            {
                revelacao.SetActive(true);

            }
            else if (badEnding2 == false)
            {
                badEnding2.SetActive(true);
            }
            else if (badEnding3 == false)
            {
                badEnding3.SetActive(true);
            }
        }

        if (good)
        {
            if (revelacao == false)
            {
                revelacao.SetActive(true);

            }
            else if (goodEnding2 == false)
            {
                goodEnding2.SetActive(true);
            }
            else if (goodEnding3 == false)
            {
                goodEnding3.SetActive(true);
            }
        }

        if (perfect)
        {
            if (revelacao == false)
            {
                revelacao.SetActive(true);

            }
            else if (perfectEnding2 == false)
            {
                perfectEnding2.SetActive(true);
            }
            else if (perfectEnding3 == false)
            {
                perfectEnding3.SetActive(true);
            }
        }
    }



}
