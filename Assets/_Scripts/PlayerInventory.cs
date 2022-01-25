using System;
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
    public List<Item> playerCostumes;
    int playerGold;

    SpriteRenderer renderer;
    int currentCostume;
    Rigidbody2D rb;
    [SerializeField] Text infobarText;
    [SerializeField] Button[] costumeButtons;
    [SerializeField] GameObject[] costumes;
    public Item startingCostume;
    Image costumeButtonImage;


    public Item equippedCostume;
    Item previousCostume;
    Sprite currentCostumeIcon;
    PlayerController pc;
    bool walking;
    void Start()
    {
        playerGold = startingGold;
        goldText.text = playerGold.ToString();
        goldText2.text = playerGold.ToString();

        pc = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        currentCostumeIcon = startingCostume.GetIcon();
        walking = false;
        currentCostume = startingCostume.GetCostumeIndex();
        renderer = GetComponentInChildren<SpriteRenderer>();
        playerCostumes.Add(startingCostume);
        equippedCostume = startingCostume;
        previousCostume = equippedCostume;

    }

    private void Update()
    {
        UpdateInventoryImages();
        ManageCostumeButtons();
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
        foreach (Image slot in inventorySlotImages)
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

    private void ManageCostumeButtons()
    {
        int i = 0;
        foreach (Button button in costumeButtons)
        {
            if (i < playerCostumes.Count -1)
            {
                costumeButtons[i].image.sprite = playerCostumes[i + 1].GetIcon();
                costumeButtons[i].gameObject.SetActive(true);
            }
            else
            {
                costumeButtons[i].GetComponent<Image>().sprite = emptySlotImage;
                costumeButtons[i].gameObject.SetActive(false);
            }
            i++;
        }
    }

    void ButtonBehaviour(int index)
    {
        walking = pc.GetWalking();
        if (!walking)
        {
            previousCostume = equippedCostume;
            equippedCostume = playerCostumes[index];
            playerCostumes[index] = previousCostume;
            pc.ProcessTag(equippedCostume.GetCostumeIndex());
        }
        else
        {
            infobarText.text = "I can't change costumes while walking. I'm not that agile.";
        }
    }

    #region Button Functions

    public void ButtonOne()
    {
        ButtonBehaviour(1);
    }

    public void ButtonTwo()
    {
        ButtonBehaviour(2);
    }
    public void ButtonThree()
    {
        ButtonBehaviour(3);
    }
    public void ButtonFour()
    {
        ButtonBehaviour(4);
    }
    public void ButtonFive()
    {
        ButtonBehaviour(5);
    }
    #endregion
}
