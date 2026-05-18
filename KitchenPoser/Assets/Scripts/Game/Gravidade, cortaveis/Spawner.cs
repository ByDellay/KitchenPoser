using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab que será criado
    public GameObject Ingrediente;

    // Tempo entre cada spawn
    public float SpawnTime = 1f;

    void Start()
    {
        // Repete a função Spawnar()
        // a cada 1 segundo
        InvokeRepeating(nameof(Spawnar), 0f, SpawnTime);
    }

    void Spawnar()
    {
        float randomX = Random.Range(-5f, 5f);

        Vector3 pos = new Vector3(randomX, transform.position.y, 0);

        Instantiate(Ingrediente, pos, Quaternion.identity);

        // Cria o objeto na posição do Spawner
        Instantiate(Ingrediente, transform.position, Quaternion.identity);
    }
}