using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeManager : MonoBehaviour
{
    bool selling;
    [SerializeField] NpcInventory clothesShop;
    [SerializeField] NpcInventory foodShop;
    [SerializeField] NpcInventory candyShop;
    [SerializeField] NpcInventory decorShop;
    [SerializeField] Text modeButtonText;
    [SerializeField] Text tradeChat;


    [SerializeField] GameObject[] trades;
    [SerializeField] Button[] tradeButtons;

    [SerializeField] GameObject panel;

    List<Item> displayItems;

    NpcInventory currentTradingPartner;

    PlayerInventory pi;
    DialogueManager dm;
    int i;

    void Start()
    {
        i = 0;
        panel.SetActive(false);
        selling = false;
        modeButtonText.text = "Mode: Buying";
        tradeChat.text = "I can sell you...";
        pi = FindObjectOfType<PlayerInventory>();
        dm = FindObjectOfType<DialogueManager>();

        foreach (GameObject go in trades)
        {
            trades[i].SetActive(false);
            i++;
        }
        i = 0;
    }

    public void SetUpShop()
    {
        panel.SetActive(true);
        GetTradingPartner();

        if (!selling)
        {
            displayItems = currentTradingPartner.inventory;

            modeButtonText.text = "Mode: Buying";
            tradeChat.text = "I can sell you...";

        }
        else
        {
            modeButtonText.text = "Mode: Selling";
            tradeChat.text = "I will buy...";
            if (currentTradingPartner == clothesShop)
            {
                displayItems = pi.playerCostumes;
                List<Item> itemsWithThisTag = new List<Item>();
                foreach (Item item in pi.playerCostumes)
                {
                    if (item.IsAdmissible())
                    {
                        itemsWithThisTag.Add(item);
                    }
                }
                displayItems = itemsWithThisTag;
            }
            else
            {
                ItemType willBuyThis = currentTradingPartner.WillBuy();
                List<Item> itemsWithThisTag = new List<Item>();
                foreach(Item item in pi.playerItems)
                {
                    if(item.GetItemType() == willBuyThis)
                    {
                        itemsWithThisTag.Add(item);
                    }
                }
                displayItems = itemsWithThisTag;
            }
        }
        i = 0;
        foreach (GameObject button in trades)
        {
            if(displayItems.Count == 0)
            {
                button.SetActive(false);
            }

            else if (i < displayItems.Count)
            {
                button.SetActive(true);
                Item item = displayItems[i];
                Text[] textboxes = trades[i].GetComponentsInChildren<Text>();
                textboxes[0].text = item.GetName();
                if (!selling)
                {
                    textboxes[1].text = item.GetBuyPrice().ToString();
                }
                else
                {
                    textboxes[1].text = item.GetSellPrice().ToString();

                }
            }
            else
            {
                button.SetActive(false);
            }
            i++;
        }
    }
    void GetTradingPartner()
    {
        string shopkeeper = dm.GetName();
        switch (shopkeeper)
        {
            case "Nicole Boyle": currentTradingPartner = foodShop; break;
            case "Rosalyn Perry": currentTradingPartner = decorShop; break;
            case "Donna Hershell": currentTradingPartner = candyShop; break;
            case "Lady Helen Lindsay": currentTradingPartner = clothesShop; break;
            default: currentTradingPartner = null; break;
        }
    }

    public void ModeButton()
    {
        selling = !selling;
        SetUpShop();
    }

    public void CloseButton()
    {
        selling = false;
        panel.SetActive(false);
        dm.ActivateButtonOne();
    }

    void TradeButtonFunction(int index)
    {
        if (!selling)
        {
            int itemCost = displayItems[index].GetBuyPrice();
            if (itemCost <= pi.GetPlayerGold())
            {
                pi.ChangePlayerGold(-displayItems[index].GetBuyPrice());
                if (currentTradingPartner == clothesShop)
                {
                    pi.playerCostumes.Add(displayItems[index]);
                }
                else
                {
                    pi.playerItems.Add(displayItems[index]);
                }
                currentTradingPartner.inventory.Remove(displayItems[index]);
            }
            else
            {
                tradeChat.text = "Insufficient funds!";
                return;
            }
        }
        else
        {
            pi.ChangePlayerGold(displayItems[index].GetSellPrice());
            currentTradingPartner.inventory.Add(displayItems[index]);
            if (currentTradingPartner == clothesShop)
            {
                pi.playerCostumes.Remove(displayItems[index]);
            }
            else
            {
                pi.playerItems.Remove(displayItems[index]);
            }
        }
        SetUpShop();
    }
    #region Buttons
    public void TradeButtonOne()
    {
        TradeButtonFunction(0);
    }
    public void TradeButtonTwo()
    {
        TradeButtonFunction(1);
    }
    public void TradeButtonThree()
    {
        TradeButtonFunction(2);
    }
    public void TradeButtonFour()
    {
        TradeButtonFunction(3);
    }
    public void TradeButtonFive()
    {
        TradeButtonFunction(4);
    }
    #endregion
}
