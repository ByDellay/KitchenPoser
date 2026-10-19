using UnityEngine;
using UnityEngine.UI;

public class CookRecipeButton : MonoBehaviour
{
    public Alimentos.RecipeType Type;
    public Button ButtonCook;
    public Sprite RecipeImage;

    //public ingrediente, vbai ter um pra cada

/*cada uma das variáveis abaixo é um valor inteiro definido no inspector.
eles são usados na função CookRecipe, naquele if com muitos "&&".
*/
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
          //Instance = this; 
         
/*Adiciona o ouvinte do botão (isso a gente ja usou)
*/
        ButtonCook.onClick.AddListener(SelectRecipe);
    }

    private void SelectRecipe()
    {
          GameManager.Instance.CurrentRecipe = Type; //Avisa pro game manager que a receita atual é a mesma desse script
          GameManager.Instance.ShowRecipeImage(RecipeImage);

          Debug.Log("Receita atual: " + GameManager.Instance.CurrentRecipe);
    }

    public void CookRecipe()
    {
/*Aqui define uma variável que pega a quantidade de cada ingrediente que tu possui no invetario, só pra não ter que escrever:

GameManager.Instance.inventory[Alimentos.ItemType] em CADA IF.
*/

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
       

/*Esse if gigante só confere as quantidades pra não acabar ficando com ingrediente negativo
*/
       if (AbacaxiInv >= AbacaxiDecrease && ArrozInv >= ArrozDecrease
            && CarneInv >= CarneDecrease && FarinhaInv >= FarinhaDecrease
            && FeijaoInv >= FeijaoDecrease && FrangoInv >= FrangoDecrease
            && PeixeInv >= PeixeDecrease && QueijoInv >= QueijoDecrease
            && TomateInv >= TomateDecrease)
       {

          /*Diminui de todos os itens(colocar 0 no inspector caso nao tenha na receita)
*/ GameManager.Instance.SubtractItem(Alimentos.ItemType.Abacaxi, AbacaxiDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Arroz, ArrozDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Carne, CarneDecrease);

            GameManager.Instance.SubtractItem(Alimentos.ItemType.Farinha, FarinhaDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Feijao, FeijaoDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Frango, FrangoDecrease);

            GameManager.Instance.SubtractItem(Alimentos.ItemType.Peixe, PeixeDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Queijo, QueijoDecrease);
            GameManager.Instance.SubtractItem(Alimentos.ItemType.Tomate, TomateDecrease);

           /*Aqui é onde ele adiciona +1 no
inventário de receitas, ou não, caso não tenha ingrediente o bastante no if gigante dali de cima

*/
 GameManager.Instance.recipesCount[Type] ++;
            Debug.Log("Receita Feita: " + Type);
       }
       else
       {
            Debug.Log("Não conseguiu cozinhar");
       }
    }
}