using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Prefab que ser� criado
    public GameObject[] Alimentos;
    public GameObject SpawnerObject;

    //spawn
    public float SpawnTime = 1f;
    public Transform leftSpawn;
    public Transform rightSpawn;

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


        Instantiate(Alimentos[i], transform);
        transform.SetParent(meuPai);
        

        // Cria o objeto na posi��o do Spawner
        //Instantiate(Ingrediente, transform.position, Quaternion.identity);
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