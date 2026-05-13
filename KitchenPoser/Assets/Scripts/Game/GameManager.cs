using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int AbacaxiCount;
    public int ArrozCount;
    public int CarneCount;
    public int FarinhaCount;
    public int FeijãoCount;
    public int FrangoCount;
    public int PeixeCount;
    public int QueijoCount;
    public int TomateCount;

    private void Awake()
    {
        Instance = this;
    }

    // Método para adicionar um item ao inventário
    public void AddItem(Alimentos.ItemType type)
    {
        switch (type) // a função switch analisa casos e ve oque faz em cada um deles, nesse caso, cada tipo de alimento tem um contador diferente, e a função switch analisa qual tipo de alimento foi adicionado e incrementa o contador correspondente
        {
            // Esse case representa abacaxi e incrementa o contador correspondente
            case Alimentos.ItemType.Abacaxi:
                AbacaxiCount++;
                Debug.Log("Abacaxis: " + AbacaxiCount);
                break;

            case Alimentos.ItemType.Arroz:
                ArrozCount++;
                Debug.Log("Arroz: " + ArrozCount);
                break;

            case Alimentos.ItemType.Carne:
                CarneCount++;
                Debug.Log("Carnes: " + CarneCount);
                break;

            case Alimentos.ItemType.Frango:
                FrangoCount++;
                Debug.Log("Frangos: " + FrangoCount);
                break;

            case Alimentos.ItemType.Peixe:
                PeixeCount++;
                Debug.Log("Peixes: " + PeixeCount);
                break;

            case Alimentos.ItemType.Queijo:
                QueijoCount++;
                Debug.Log("Queijos: " + QueijoCount);
                break;

            case Alimentos.ItemType.Tomate:
                TomateCount++;
                Debug.Log("Tomates: " + TomateCount);
                break;
        }
    }
}
