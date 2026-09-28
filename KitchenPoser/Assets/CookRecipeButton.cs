using UnityEngine;
using UnityEngine.UI;

public class CookRecipeButton : MonoBehaviour
{
    public Alimentos.RecipeType Type;
    public Button ButtonCook;


    void Start()
    {
        ButtonCook.onClick.AddListener(CookRecipe);
    }

    private void CookRecipe()
    {
        switch (Type)
        {
            case Alimentos.RecipeType.PaoDeQueijo:
                Debug.Log("PãoDequeijop!!!!");
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
