using UnityEngine;
using UnityEngine.UI;

public class CookRecipeButton : MonoBehaviour
{
    public static CookRecipeButton Instance; // Define a instancia (que é ele mesmo)
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
          Instance = this;
          ButtonCook.onClick.AddListener(SelectRecipe);
    }

    private void SelectRecipe()
    {
          Debug.Log(GameManager.Instance.CurrentRecipe);
          GameManager.Instance.CurrentRecipe = Type;
          Debug.Log(GameManager.Instance.CurrentRecipe);
    }

    public void CookRecipe()
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

       ///////////////////////////////////////////////////////////////////////////////
       
       if (AbacaxiInv >= AbacaxiDecrease && ArrozInv >= ArrozDecrease
            && CarneInv >= CarneDecrease && FarinhaInv >= FarinhaDecrease
            && FeijaoInv >= FeijaoDecrease && FrangoInv >= FrangoDecrease
            && PeixeInv >= PeixeDecrease && QueijoInv >= QueijoDecrease
            && TomateInv >= TomateDecrease)
       {

            GameManager.Instance.SubtractItem(Alimentos.ItemType.Abacaxi, AbacaxiDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Arroz, ArrozDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Carne, CarneDecrease);

            GameManager.Instance.SubtractItem(Alimentos.ItemType.Farinha, FarinhaDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Feijao, FeijaoDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);

            GameManager.Instance.SubtractItem(Alimentos.ItemType.Peixe, PeixeDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Queijo, QueijoDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Tomate, TomateDecrease);

            GameManager.Instance.recipesCount[Type] ++;
            Debug.Log(Type);
       }
       else
       {
            Debug.Log("Não conseguiu cozinhar");
       }
    }
}