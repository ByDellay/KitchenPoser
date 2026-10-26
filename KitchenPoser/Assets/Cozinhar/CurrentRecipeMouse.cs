using UnityEngine;
using UnityEngine.UI;

public class CurrentRecipeMouse : MonoBehaviour
{
    //public Image CurrentRecipeImage;
    public SpriteRenderer SpriteRenderer;
    //public GameObject CurrentRecipeObject;
    public Vector3 Offset;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        transform.position = mousePos + Offset;

        SpriteRenderer.sprite = GameManager.Instance.CurrentRecipeSprite.sprite;
    }
}
