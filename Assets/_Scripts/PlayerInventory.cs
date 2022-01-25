using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Image[] inventorySlotImages;
    [SerializeField] Text goldText;
    [SerializeField] Text goldText2;
    [SerializeField] int startingGold;

    public List<Item> playerItems;
    public List<Item> ownedCostumes;
    int playerGold;
    CostumeManager cm;
    void Start()
    {
        playerGold = startingGold;
        goldText.text = playerGold.ToString();
        goldText2.text = playerGold.ToString();
        cm = FindObjectOfType<CostumeManager>();
        ownedCostumes = cm.GetPlayerCostumes();
    }

    public int GetPlayerGold()
    {
        return playerGold;
    }

    public void ChangePlayerGold(int amount)
    {
        playerGold += amount;
        goldText.text = playerGold.ToString();
        goldText2.text = playerGold.ToString();
    }

    public void UpdateInventoryImages()
    {
        int i = 0;
        foreach(Item item in playerItems)
        {
            inventorySlotImages[i].sprite = item.GetIcon();
        }
    }

    public void AddItem(Item item)
    {
        //int position = playerItems.Length;
        //playerItems[position] = item;
        playerItems.Add(item);
        //UpdateInventoryImages();
    }

    /*public void RemoveItem(Item item)
    {
        int i = 0;
        int position = System.Array.IndexOf(playerItems, item);
        foreach(Item it in playerItems)
        {
            if (i <= position) return;
            else playerItems[i - 1] = it;
            i++;
        }
        UpdateInventoryImages();
    }*/

    //public void AddCostume(Item item)
    //{
    //    cm.AddCostume(item);
    //    int position = ownedCostumes.Count;
    //    ownedCostumes[position] = item;
    //}

    /*public void RemoveCostume(Item item)
    {
        cm.RemoveCostume(item);
        int i = 0;
        int position = System.Array.IndexOf(ownedCostumes, item);
        foreach (Item it in ownedCostumes)
        {
            if (i <= position) return;
            else ownedCostumes[i - 1] = it;
            i++;
        }
    }*/

    public List<Item> GetPlayerInventory()
    {
        return playerItems;
    }

    public List<Item> GetPlayerCostumes()
    {
        return ownedCostumes;
    }
}
