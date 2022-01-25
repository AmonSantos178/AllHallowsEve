using System.Collections.Generic;
using UnityEngine;

public class NpcInventory : MonoBehaviour
{
    [SerializeField] List<Item> startingInventory;
    public List<Item> inventory;

    [SerializeField] ItemType willBuy;
    void Start()
    {
        inventory = startingInventory;
    }

    public ItemType WillBuy()
    {
        return willBuy;
    }
}
