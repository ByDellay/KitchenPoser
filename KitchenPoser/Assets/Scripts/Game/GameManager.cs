using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // invent�rio
    public Dictionary<Alimentos.ItemType, int> inventory =
        new Dictionary<Alimentos.ItemType, int>();

    private void Awake()
    {
        // singleton
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // inicializa todos alimentos com 0
        foreach (Alimentos.ItemType item in
                 System.Enum.GetValues(typeof(Alimentos.ItemType)))
        {
            inventory[item] = 0;
        }
    }

    public void AddItem(Alimentos.ItemType type)
    {
        inventory[type]++;

        Debug.Log(type + ": " + inventory[type]);
    }

    public int GetItemCount(Alimentos.ItemType type)
    {
        return inventory[type];
    }
    // evento para abrir o menu, tem que fazer ainda, por favor faz acabar eu quero morrer
    /*public void AbriuMenu()
    {
        {
            print("abriu");
            .Invoke();
        }
    }*/
}