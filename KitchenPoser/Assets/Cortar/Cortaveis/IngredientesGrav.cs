using UnityEngine;
using System.Collections;

public class IngredientesGrav : MonoBehaviour
{
    // Guarda o Rigidbody2D do objeto
    Rigidbody2D RigidBody;
    public ParticleSystem Particle;
    public Alimentos.ItemType Type;
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
    public ParticleSystem ParticulaCorte;
    SpriteRenderer sr;




    void Start()
    {
        GameObject Spawner = GameObject.FindWithTag("Spawner");
        if (Spawner != null)
        {
            transform.SetParent(Spawner.transform);
        } 

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
            if (hit != null && hit.gameObject == gameObject && AlreadyCutted == false && !CompareTag("ObjetoDuro")) // se não for um objeto duro
            {
                AlreadyCutted = true;
                GameManager.Instance.AddItem(Type);
                sr.sprite = SpriteCortado;
                Instantiate(ParticulaCorte, transform.position + new Vector3(0f, 0f, -0.5f), Quaternion.identity); //spawna as particulas levemente a frente do ingrediente quando cortado

                StartCoroutine(Squish());
               
            }
            else if (hit != null && hit.gameObject == gameObject && AlreadyCutted == false && CompareTag("ObjetoDuro")) // se for um objeto duro
            {
                AlreadyCutted = true;
                GameManager.Instance.TotalFails++;
                GameObject.FindWithTag("MainCamera").GetComponent<ScreenShake>().DoScreenShake(); // Chama o evento que treme a tela
                GameManager.Instance.NoBreak();
                //cortar = desabilitado por 3 segundos (tem que criar isso ainda)
            }
        }
    }
    IEnumerator Squish()
    {
    // Guarda a escala atual do objeto
    Vector3 original = transform.localScale;
        
    // Altera a escala do objeto:
    transform.localScale = new Vector3(
        original.x * 1.3f,// Aumenta a largura (x)
        original.y * 0.7f,// Diminui a altura (y)
        original.z// Mantém a profundidade (z)
    );

    // Espera 0,08 segundos antes de continuar
    yield return new WaitForSeconds(0.08f);

    // Retorna o objeto para a escala original
    transform.localScale = original;
    }
}