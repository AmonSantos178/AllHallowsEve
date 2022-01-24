using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Image[] inventorySlotImages;
    [SerializeField] Text goldText;
    [SerializeField] Text goldText2;
    [SerializeField] int startingGold;

    Item[] playerItems;
    int playerGold;
    void Start()
    {
        playerGold = startingGold;
        goldText.text = playerGold.ToString();
        goldText2.text = playerGold.ToString();
    }

    void Update()
    {

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
        int position = playerItems.Length;
        playerItems[position] = item;
        UpdateInventoryImages();
    }

    public void RemoveItem(Item item)
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
    }
}
