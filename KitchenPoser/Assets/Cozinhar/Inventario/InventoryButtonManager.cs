using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryButtonManager : MonoBehaviour
{
    public Alimentos.ItemType Type;

    [SerializeField] private Button ThisIngredientButton;

    void Start()
    {
        ThisIngredientButton.onClick.AddListener(CallAddOnHand);
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

        //_ThisIngredient.GetComponent<InventoryIngredient>().DefineType(_Type);
    }
}
