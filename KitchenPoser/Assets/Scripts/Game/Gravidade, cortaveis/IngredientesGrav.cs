using UnityEngine;

public class IngredientesGrav : MonoBehaviour
{
    // Guarda o Rigidbody2D do objeto
    Rigidbody2D RigidBody;

    // Força máxima que o objeto pode receber pra subir
    int MaxForceV = 1500;
    // Força mínima que o objeto pode receber pra subir
    int MinForceV = 1200;

    // Força máxima que o objeto pode receber pro lado
    int MaxForceH = 250;
    // Força mínima que o objeto pode receber pro lado
    int MinForceH = -250;

    // Altura em Y onde o objeto será deletado
    float DeletPos = -100f;

    void Start()
    {
        // Pega o Rigidbody2D do próprio objeto
        RigidBody = GetComponent<Rigidbody2D>();

        // Escolhe uma força vertical aleatória
        float RandomForce = Random.Range(MinForceV, MaxForceV);

        // Escolhe uma direção horizontal aleatória
        // Negativo = esquerda
        // Positivo = direita
        float RandomX = Random.Range(MinForceH, MaxForceH);

        // Cria um vetor de força:
        // X = lado
        // Y = altura
        Vector2 force = new Vector2(RandomX, RandomForce);

        // Aplica a força no objeto
        RigidBody.AddForce(force);
    }

    void Update()
    {
        // Verifica se o objeto caiu abaixo da tela
        if (transform.position.y < DeletPos)
        {
            // Mostra mensagem no console
            Debug.Log("Sumiu");

            // Deleta o objeto da cena
            Destroy(gameObject);
        }
    }
}