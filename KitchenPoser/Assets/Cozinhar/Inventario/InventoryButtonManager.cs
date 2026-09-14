using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryButtonManager : MonoBehaviour
{
    Stack<GameObject> OnHandIngredients = new Stack<GameObject>();
    public Alimentos.ItemType Type;

    public GameObject ThisIngredient;
    [SerializeField] private Button ThisIngredientButton;

    void Start()
    {
        ThisIngredientButton.onClick.AddListener(CallAddOnHand);
    }

    public void CallAddOnHand()
    {
        AddOnHand(ThisIngredient);
    }

    public void AddOnHand(GameObject _ThisIngredient)
    {
        OnHandIngredients.Push(_ThisIngredient);
        GameManager.Instance.SubtractItem(Type);
        GameManager.Instance.UpdateItemCount();

        _ThisIngredient.GetComponent<InventoryIngredient>().DefineType(Type);
    }
}
