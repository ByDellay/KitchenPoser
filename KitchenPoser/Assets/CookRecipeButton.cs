using UnityEngine;
using UnityEngine.UI;

public class CookRecipeButton : MonoBehaviour
{
    public Alimentos.RecipeType Type;
    public Button ButtonCook;

    //public ingrediente, vbai ter um pra cada

    [SerializeField] private int AbacaxiDecrease;
    [SerializeField] private int ArrozDecrease;
    [SerializeField] private int CarneDecrease;

    [SerializeField] private int FarinhaDecrease;
    [SerializeField] private int FeijaoDecrease;
    [SerializeField] private int FrangoDecrease;

    [SerializeField] private int PeixeDecrease;
    [SerializeField] private int QueijoDecrease;
    [SerializeField] private int TomateDecrease;


    void Start()
    {
        ButtonCook.onClick.AddListener(CookRecipe);
    }

    private void CookRecipe()
    {
        int AbacaxiInv = GameManager.Instance.inventory[Alimentos.ItemType.Abacaxi];
        int ArrozInv = GameManager.Instance.inventory[Alimentos.ItemType.Arroz];
        int CarneInv = GameManager.Instance.inventory[Alimentos.ItemType.Carne];

        int FarinhaInv = GameManager.Instance.inventory[Alimentos.ItemType.Farinha];
        int FeijaoInv = GameManager.Instance.inventory[Alimentos.ItemType.Feijao];
        int FrangoInv = GameManager.Instance.inventory[Alimentos.ItemType.Frango];

        int PeixeInv = GameManager.Instance.inventory[Alimentos.ItemType.Peixe];
        int QueijoInv = GameManager.Instance.inventory[Alimentos.ItemType.Queijo];
        int TomateInv = GameManager.Instance.inventory[Alimentos.ItemType.Tomate];

        switch (Type)
        {
            case Alimentos.RecipeType.BaiaoDeDois:
                if (FeijaoInv >= FeijaoDecrease && ArrozInv >= ArrozDecrease && QueijoInv >= QueijoDecrease && FrangoInv >= FrangoDecrease)
                {
                    //baiao de 2 = true, apenas uma vez vai cozinhar esse
                    //4 feijão, 4 arroz, 3 queijo, 3 frango
                    Debug.Log("Baiao!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Queijo, QueijoDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Arroz, ArrozDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Feijao, FeijaoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;
                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.Burrito:
                if (FeijaoInv >= FeijaoDecrease && FarinhaInv >= FarinhaDecrease && CarneInv >= CarneDecrease && ArrozInv >= ArrozDecrease)
                {
                    //6 feijão, 3 farinha, 3 carne, 3 arroz
                    Debug.Log("Burrito!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Feijao, FeijaoDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Arroz, ArrozDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Carne, CarneDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Farinha, FarinhaDecrease);
                    GameManager.Instance.recipesCount[Type] ++;
                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.Chester:
                if (FrangoInv >= FrangoDecrease && ArrozInv >= ArrozDecrease && AbacaxiInv >= AbacaxiDecrease && TomateInv >= TomateDecrease)
                {
                    //6 frangos, 4 tomate, 2 arroz, 1 abacaxi
                    Debug.Log("Chester!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Abacaxi, AbacaxiDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Arroz, ArrozDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Tomate, TomateDecrease);
                    GameManager.Instance.recipesCount[Type] ++;
                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.Coxinha:
                if (FrangoInv >= FrangoDecrease && FarinhaInv >= FarinhaDecrease && TomateInv >= TomateDecrease)
                {
                    //5 farinha, 6 frangos, 2 tomate
                    Debug.Log("Coxinhou!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Farinha, FarinhaDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Tomate, TomateDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.PaoDeQueijo:
                if (FarinhaInv >= FarinhaDecrease && QueijoInv >= QueijoDecrease)
                {
                    //10 Queijo, 3 farinha
                    Debug.Log("Meia-noite!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Farinha, FarinhaDecrease);
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Queijo, QueijoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.PeixeFrito:
                if (FrangoInv >= FrangoDecrease)
                {
                    Debug.Log("Coxinhou!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.PeixeNoAbacaxi:
                if (FrangoInv >= FrangoDecrease)
                {
                    Debug.Log("Coxinhou!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.PicanhaInvertida:
                if (FrangoInv >= FrangoDecrease)
                {
                    Debug.Log("Coxinhou!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.PratoFeito:
                if (FrangoInv >= FrangoDecrease)
                {
                    Debug.Log("Coxinhou!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.Pizza:
                if (FrangoInv >= FrangoDecrease)
                {
                    Debug.Log("Coxinhou!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            case Alimentos.RecipeType.Sushi:
                if (FrangoInv >= FrangoDecrease)
                {
                    Debug.Log("Coxinhou!");
                    GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);
                    GameManager.Instance.recipesCount[Type] ++;

                }
                else Debug.Log("Não tem o suficiente!");
            break;

            default:
                Debug.Log("Não cozinhou nada!");
                break;
            
        }
        //GameManager.Instance.recipesCount[Type] ++;
    }
}
