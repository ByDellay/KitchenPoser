using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab que ser� criado
    public GameObject[] Alimentos;
    public GameObject SpawnerObject;

    //spawn
    public float SpawnTime = 1f; // Tempo de espera entre cada spawner
    private float _Timer; // Contador do tempo
    public Transform leftSpawn;
    public Transform rightSpawn;

    void Update()
    {
        _Timer += Time.deltaTime; // Contador de tempo

        if (_Timer >= SpawnTime) // O tempo ja passou o suficiente?
        {
            Spawnar();
            _Timer = 0f;
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

    /*void Spawnar2()
    {
        //instancia o prefab na cena
        GameObject Comida = Instantiate(Alimentos, transform.position, Quaternion.identity);

        //gera um valor aleatorio e armazena em uma variavel
        float newX = Random.Range(leftSpawn.position.x, rightSpawn.position.x);

        //atribui a nova posição para o inimigo
        Comida.transform.position = new Vector2(newX, transform.position.y);
    } */
}