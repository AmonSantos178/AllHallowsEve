using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Image[] inventorySlotImages;
    [SerializeField] Sprite emptySlotImage;
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

    private void Update()
    {
        UpdateInventoryImages();
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
        foreach(Image slot in inventorySlotImages)
        {
            if (i < playerItems.Count)
            {
                inventorySlotImages[i].sprite = playerItems[i].GetIcon();
            }
            else
            {
                inventorySlotImages[i].sprite = emptySlotImage;
            }
            i++;
        }
    }
}
