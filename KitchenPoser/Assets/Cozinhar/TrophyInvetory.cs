using UnityEngine;

public class TrophyInvetory : MonoBehaviour
{
    public static TrophyInvetory Instance; // Define a instancia (que é ele mesmo)
    public GameObject[] InventoryTrophys;

    void Start()
    {
        Instance = this;
    }

    public void TrophyAtivator(Alimentos.RecipeType Type)
    {
        switch (Type)
        {
            case Alimentos.RecipeType.BaiaoDeDois:
                InventoryTrophys[0].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.Burrito:
                InventoryTrophys[1].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.Chester:
                InventoryTrophys[2].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.Coxinha:
                InventoryTrophys[3].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.PaoDeQueijo:
                InventoryTrophys[4].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.PeixeFrito:
                InventoryTrophys[5].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.PeixeNoAbacaxi:
                InventoryTrophys[6].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.PicanhaInvertida:
                InventoryTrophys[7].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.PratoFeito:
                InventoryTrophys[8].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.Pizza:
                InventoryTrophys[9].GetComponent<SpriteRenderer>().color = Color.white;
                break;

            case Alimentos.RecipeType.Sushi:
                InventoryTrophys[10].GetComponent<SpriteRenderer>().color = Color.white;
                break;
        }
    }
}
