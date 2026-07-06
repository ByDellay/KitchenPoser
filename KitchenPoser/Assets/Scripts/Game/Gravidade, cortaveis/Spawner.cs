using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab que ser� criado
    public GameObject[] Alimentos;

    // Tempo entre cada spawn
    public float SpawnTime = 1f;

    public Transform meuPai;

    void Start()
    {
        // Repete a fun��o Spawnar()
        // a cada 1 segundo
        InvokeRepeating(nameof(Spawnar), 0f, SpawnTime);
    }

    void Spawnar()
    {
        float randomX = Random.Range(-5f, 5f);

        Vector3 pos = new Vector3(randomX, transform.position.y, 0);
        int i = Random.Range(0, Alimentos.Length);


        Instantiate(Alimentos[i], pos, Quaternion.identity);
        transform.SetParent(meuPai);

        // Cria o objeto na posi��o do Spawner
        //Instantiate(Ingrediente, transform.position, Quaternion.identity);
    }
}