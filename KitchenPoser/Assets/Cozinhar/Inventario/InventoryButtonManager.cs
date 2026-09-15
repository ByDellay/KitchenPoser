using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryButtonManager : MonoBehaviour
{
    public Alimentos.ItemType Type;

    [SerializeField] private Button ThisIngredientButton;

    [SerializeField] private GameObject IngredientIcon;
    [SerializeField] private float IngredientIconOffset = 3f;

    private List<GameObject> IngredientsOnHand = new List<GameObject>();

    void Start()
    {
        ThisIngredientButton.onClick.AddListener(CallAddOnHand);
    }

    void Update()
    {
        FollowMouse();
    }

    public void CallAddOnHand()
    {
        AddOnHand(Type);
    }

    public void AddOnHand(Alimentos.ItemType _Type)
    {
        GameManager.Instance.OnHandIngredients.Push(_Type);
        GameManager.Instance.SubtractItem(_Type);
        GameManager.Instance.UpdateItemCount();

        GameObject Ingredient = Instantiate(IngredientIcon);

        IngredientsOnHand.Add(Ingredient);
    }

    void FollowMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

            for (int i = 0; i < IngredientsOnHand.Count; i++)
            {
                IngredientsOnHand[i].transform.position = mousePos + Vector3.right * i * IngredientIconOffset;
            }
    }
}
