using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    #region Variables
    public Item[] relevantItems;

    public bool scaredDermot;
    public bool cheeredWillie;
    public bool cheeredMartin;

    public bool hasLily;
    public bool hasLunch;
    public bool hasCostume;
    public bool hasCandles;
    public bool hasEggs;
    public bool hasFishySticks;
    public bool hasGifts;

    public bool emilyQuest;
    public bool friendQuest;
    public bool momQuest;
    public bool gravediggerQuest;
    public bool stanQuest;

    public bool hiredBard;

    public int decorations;
    public int sweets;

    PlayerInventory pi;
    string currentNameCheck;
    #endregion

    void Start()
    {
        pi = FindObjectOfType<PlayerInventory>();
    }

    void Update()
    {
        UpdateBools();
    }

    void UpdateBools()
    {
        foreach (Item item in relevantItems)
        {
            string itemName = item.GetName();
            GetRelatedVariable(itemName);
        }

        sweets = pi.playerItems.FindAll(FindSweets).Count;
        decorations = pi.playerItems.FindAll(FindDecorations).Count;
        if(pi.playerItems.FindAll(CountGifts).Count == 2)
        {
            hasGifts = true;
        }
        else
        {
            hasGifts = false;
        }

        if(pi.playerCostumes.Count > 1)
        {
            hasCostume = true;
        }
        else
        {
            hasCostume = false;
        }
    }
    #region Checks
    public bool CheckGameCompletion()
    {
        if (decorations >= 1 && sweets >= 2)
        {
            if (hasCostume && hiredBard)
            {
                return true;
            }
            else return false;
        }
        else return false;
    }

    public bool CheckQuestCompletion(string tag)
    {
        switch (tag)
        {
            case "Emily": return emilyQuest;
            case "Grave": return gravediggerQuest;
            case "Mom": return momQuest;
            case "Friend": return friendQuest;
            case "Stan": return stanQuest;
            default: return false;
        }
    }
    #endregion

    #region FindMethods
    private bool FindItemWithName(Item item)
    {
        if(item.GetName() == currentNameCheck)
        {
            return true;
        }
       else
        {
            return false;
        }
    }

    private bool FindSweets(Item item)
    {
        if (item.GetItemType() == ItemType.Sweet)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool CountGifts(Item item)
    {
        if (item.IsGift())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool FindDecorations(Item item)
    {
        if (item.GetItemType() == ItemType.Decor && item.IsAdmissible())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void GetRelatedVariable(string name)
    {
        currentNameCheck = name;
        switch (name)
        {
            case "Candle": hasCandles = pi.playerItems.Find(FindItemWithName); break;
            case "Eggs": hasEggs = pi.playerItems.Find(FindItemWithName); break;
            case "Fishy Sticks": hasFishySticks = pi.playerItems.Find(FindItemWithName); break;
            case "Lily": hasLily = pi.playerItems.Find(FindItemWithName); break;
            case "Mr. Tesker's Lunch": hasLunch = pi.playerItems.Find(FindItemWithName); break;
            default: break;
        }
    }

    public bool GiveState(string tag)
    {
        switch (tag)
        {
            case "Bard": return hiredBard;
            case "Hobbit": return cheeredMartin;
            case "Fisherman": return hasLunch;
            case "Grave": return scaredDermot;
            case "Hall": return CheckGameCompletion();
            case "Mom": return hasEggs;
            case "Friend": return hasCostume;
            case "Stan": return hasGifts;
            case "Willy": return cheeredWillie;
            default: return false;
        }
    }
    #endregion
}
