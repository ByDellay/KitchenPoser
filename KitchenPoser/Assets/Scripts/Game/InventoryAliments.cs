using UnityEngine;

public class InventoryAliments : MonoBehaviour
{

    public Alimentos.ItemType Type;
    [SerializeField] private TMP_Text InventoryText;
    [SerializeField] private Button Button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button.onClick.AddListener(DrawTextAmount);
    }

    public void DrawTextAmount(Alimentos.ItemType type) // Adicionador de item
    {
        InventoryText.text = inventory[type]; // Adiciona ao tipo
    }
}
