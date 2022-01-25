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

    public void AddItem(Item item)
    {
        inventory.Add(item);

    }


    public void RemoveItem(Item item)
    {
        //MAY BE WRONG
        inventory.Remove(item);
        /*int i = 0;
        int position = System.Array.IndexOf(inventory, item);
        foreach (Item it in inventory)
        {
            if (i <= position) return;
            else inventory[i - 1] = it;
            i++;
        }*/
    }
    /*public void RemoveItem(Item item)
    {
        int i = 0;
        int position = System.Array.IndexOf(inventory, item);
        foreach (Item it in inventory)
        {
            if (i <= position) return;
            else inventory[i - 1] = it;
            i++;
        }
    }*/

    public List<Item> GetNpcInventory()
    {
        return inventory;
    }

    public ItemType WillBuy()
    {
        return willBuy;
    }
}
