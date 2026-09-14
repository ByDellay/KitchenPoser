using UnityEngine;

public class InventoryIngredient : MonoBehaviour
{
    public void DefineType(Alimentos.ItemType Type)
    {
        int Amount = GameManager.Instance.inventory[Type];

        Debug.Log(Type + ": " + Amount);
    }
}
