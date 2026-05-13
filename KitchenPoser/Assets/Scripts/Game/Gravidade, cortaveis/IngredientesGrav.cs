using NUnit.Framework.Internal;
using UnityEngine;

public class IngredientesGrav : MonoBehaviour
{
    Rigidbody2D RigidBody;
    int MaxForce = 1000;
    int MinForce = 750;
    float DeletPos = -10f;

    void Start()
    {
        float Force = Random.Range(MaxForce, MinForce);
        print(Force);
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.AddForce(Vector2.up * Force);
    }

    void Update()
    {
        if (transform.position.y < DeletPos)
        {
            Debug.Log("Sumiu");
            Destroy(gameObject);
        }
    }
}
