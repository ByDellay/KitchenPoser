using TMPro;
using UnityEngine;

public class FinalResults : MonoBehaviour
{
    public TextMeshProUGUI pontuação;
    private void Start()
    {
        int abacaxi = GameManager.Instance.GetItemCount(Alimentos.ItemType.Abacaxi);
        int arroz = GameManager.Instance.GetItemCount(Alimentos.ItemType.Arroz);
        int carne = GameManager.Instance.GetItemCount(Alimentos.ItemType.Carne);
        int farinha = GameManager.Instance.GetItemCount(Alimentos.ItemType.Farinha);
        int feijao = GameManager.Instance.GetItemCount(Alimentos.ItemType.Feijao);
        int frango = GameManager.Instance.GetItemCount(Alimentos.ItemType.Frango);
        int peixe = GameManager.Instance.GetItemCount(Alimentos.ItemType.Peixe);
        int queijo = GameManager.Instance.GetItemCount(Alimentos.ItemType.Queijo);
        int tomate = GameManager.Instance.GetItemCount(Alimentos.ItemType.Tomate);

        pontuação.text = $"Abacaxi: {abacaxi} \n Carne: {carne} \n Peixe: {peixe} \n Tomate: {tomate}";
    }
}
