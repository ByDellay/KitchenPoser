using UnityEngine;

public class IngredientesGrav : MonoBehaviour
{
    // Guarda o Rigidbody2D do objeto
    Rigidbody2D RigidBody;
    bool AlreadyCutted = false;

    // For�a m�xima que o objeto pode receber pra subir
    int MaxForceV = 1100;
    // For�a m�nima que o objeto pode receber pra subir
    int MinForceV = 800;

    // For�a m�xima que o objeto pode receber pro lado
    int MaxForceH = 150;
    // For�a m�nima que o objeto pode receber pro lado
    int MinForceH = -150;

    // For�a m�xima que o objeto pode receber pra rota��o
    int MaxForceRotation = 50;
    // For�a m�nima que o objeto pode receber pra rota��o
    int MinForceRotation = -50;

    // Altura em Y onde o objeto ser� deletado
    float DeletPos = -100f;

    public Sprite SpriteCortado;
    SpriteRenderer sr;

    void Start()
    {
        // Pega o Rigidbody2D do pr�prio objeto
        RigidBody = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        // Escolhe uma for�a vertical aleat�ria
        float RandomForce = Random.Range(MinForceV, MaxForceV);

        // Escolhe uma for�a aleatoria para rotacionar
        float RandomRotation = Random.Range(MinForceRotation, MaxForceRotation);

        // Escolhe uma dire��o horizontal aleat�ria
        // Negativo = esquerda
        // Positivo = direita
        float RandomX = Random.Range(MinForceH, MaxForceH);

        // Cria um vetor de for�a:
        // X = lado
        // Y = altura
        Vector2 force = new Vector2(RandomX, RandomForce);
        Vector3 Rotation = new Vector3(0, 0, RandomRotation);

        // Aplica a for�a no objeto
        RigidBody.AddForce(force);
        RigidBody.angularVelocity = RandomRotation;
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

        // Verifica se bot�o esquerdo est� segurado
        if (Input.GetMouseButton(0))
        {
            // Pega posi��o do mouse na tela
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Verifica se o mouse encostou no collider
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            // Se o collider encontrado for ESTE objeto
            if (hit != null && hit.gameObject == gameObject && AlreadyCutted == false)
            {
                AlreadyCutted = true;
                GameManager.Instance.AddItem(Alimentos.ItemType.Peixe);
                sr.sprite = SpriteCortado;
            }
        }
    }
}