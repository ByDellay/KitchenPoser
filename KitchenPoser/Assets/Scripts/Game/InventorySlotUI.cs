using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    // imagem do alimento
    public Image itemImage;

    // texto da quantidade
    public TMP_Text amountText;

    // configura o slot
    public void Setup(Sprite sprite, int amount)
    {
        itemImage.sprite = sprite;

        amountText.text = amount.ToString();
    }
}