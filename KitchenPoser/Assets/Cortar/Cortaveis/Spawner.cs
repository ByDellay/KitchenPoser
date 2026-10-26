using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    // Prefab que ser� criado
    public GameObject[] Alimentos;

    //spawn
    public float SpawnTime = 5f; // Tempo de espera entre cada spawner
    private float _SpawnTimer; // Contador do tempo
    public float CutTime;
    public float CutTimer; // Contador do tempo
    public float TrueEndMoment;
    public Transform leftSpawn;
    public Transform rightSpawn;

    public bool Acabou = false;

    public float _CutTimerText;
    public TextMeshProUGUI timerShow;
    

    private void Start()
    {
        _CutTimerText = CutTime;
        DeleteChildrens();
    }
    void Update()
    {
        _SpawnTimer += Time.deltaTime; // Contador de tempo
        CutTimer += Time.deltaTime; // Contador de tempo
        _CutTimerText -= Time.deltaTime;
        if (_CutTimerText > 0)
        {
            timerShow.text = _CutTimerText.ToString("F0");
        }
        if (CutTimer <= 50)
        {
            if ((_SpawnTimer >= SpawnTime) && Acabou == false) // O tempo ja passou o suficiente?
            {
                Spawnar();
                _SpawnTimer = 0f;
            }
        }
        else if (CutTimer >= 55 && CutTimer <= 60)
        {
            if ((_SpawnTimer >= SpawnTime) && Acabou == false) // O tempo ja passou o suficiente?
            {
                Hush();
                _SpawnTimer = 0f;
            }
        }

        if ((CutTimer >= CutTime) && Acabou == false)// O tempo ja passou o suficiente?
        {
            TrueEndMoment += Time.deltaTime;
            if (TrueEndMoment >= 5)
            {
                Acabou = true;
                GameManager.Instance.NoBreak();
                TransitionsFade.Instance.CallCoroutine_LoadOtherGameSection();

            }
        }
    }

    public void TrueEnd()
    {
        //parar todos os timers
        //parar de spawnar coisa
        //tocar o animator do finish
        //esperar um tempinho e tocar o fade out
        //TODAS as coisas que forem terminar a cena de cortar devem ser chamadas por aqui
    }
    public void DeleteChildrens()
    {
            for (int i = this.transform.childCount - 1; i >= 0; i--)
            {
                Transform Filho = this.transform.GetChild(i);
            
                if (Filho.CompareTag("ObjetoCortavel"))
                {
                    Destroy(Filho.gameObject);
                }else if (Filho.CompareTag("ObjetoDuro"))
                {
                    Destroy(Filho.gameObject);
                }
            }
    }

    public void ReiniciarCiclo()
    {
        _SpawnTimer = 0f;
        CutTimer = 0f;
        _CutTimerText = CutTime;
        Acabou = false;

    }

    void Spawnar()
    {
        SpawnTime = Random.Range(0.2f, 1.2f);
        int i = Random.Range(0, Alimentos.Length);

        //instancia o prefab na cena
        GameObject Comida = Instantiate(Alimentos[i], transform);

        

        //gera um valor aleatorio e armazena em uma variavel
        float newX = Random.Range(leftSpawn.position.x, rightSpawn.position.x);

        //atribui a nova posição para o inimigo
        Comida.transform.position = new Vector2(newX, transform.position.y);
    }

    void Hush()
    {
        SpawnTime = 0.01f;
        int i = Random.Range(0, Alimentos.Length);

        //instancia o prefab na cena
        GameObject Comida = Instantiate(Alimentos[i], transform);



        //gera um valor aleatorio e armazena em uma variavel
        float newX = Random.Range(leftSpawn.position.x, rightSpawn.position.x);

        //atribui a nova posição para o inimigo
        Comida.transform.position = new Vector2(newX, transform.position.y);
    }
}