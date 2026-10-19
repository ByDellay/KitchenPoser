using UnityEngine;
using UnityEngine.UI;

public class CurrentRecipeMouse : MonoBehaviour
{
    //public Image CurrentRecipeImage;
    public SpriteRenderer SpriteRenderer;
    //public GameObject CurrentRecipeObject;
    public Vector3 Offset;

    void Start()
    {
        Offset = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos + Offset;

        SpriteRenderer.sprite = GameManager.Instance.CurrentRecipeSprite.sprite;
    }
}
