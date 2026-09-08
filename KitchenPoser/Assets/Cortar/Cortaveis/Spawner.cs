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
    public Transform leftSpawn;
    public Transform rightSpawn;

    public float _CutTimerText;
    public TextMeshProUGUI timerShow;

    private void Start()
    {
        _CutTimerText = CutTime;
    }
    void Update()
    {
        _SpawnTimer += Time.deltaTime; // Contador de tempo
        CutTimer += Time.deltaTime; // Contador de tempo
        _CutTimerText -= Time.deltaTime;
        timerShow.text = _CutTimerText.ToString("F0");

        if (_SpawnTimer >= SpawnTime) // O tempo ja passou o suficiente?
        {
            Spawnar();
            _SpawnTimer = 0f;
        }

        if (CutTimer >= CutTime) // O tempo ja passou o suficiente?
        {
            GameManager.Instance.ChangeScene(); // Troca de cena
            DeleteChildrens();
        }
    }

    public void DeleteChildrens()
    {
        int Filhos = transform.childCount;

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
}