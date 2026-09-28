using UnityEngine;
using UnityEngine.UI;

public class CookRecipeButton : MonoBehaviour
{
    public Alimentos.RecipeType Type;
    public Button ButtonCook;

    //public ingrediente, vbai ter um pra cada


    void Start()
    {
        ButtonCook.onClick.AddListener(CookRecipe);
    }

    private void CookRecipe()
    {
        switch (Type)
        {
            case Alimentos.RecipeType.PaoDeQueijo:
                //Se tiver o suficiente no inventario do item que pede aqui em cima
                Debug.Log("PãoDequeijop!!!!");//Cozinha (Add no inventario de receitas)
                //Diminui a quantidade correta no inventtario
                //toca um som, game feel etc
                break;

            case Alimentos.RecipeType.Coxinha:
                Debug.Log("Coxinhou!");
                break;

            default:
                Debug.Log("Não cozinhou nada!");
                break;
            
        }
        //GameManager.Instance.recipesCount[Type] ++;
    }
}
