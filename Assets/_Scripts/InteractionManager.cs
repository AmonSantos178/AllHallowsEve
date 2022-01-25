using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public bool scaredTesker;
    public bool scaredDermot;
    public bool cheeredWillie;
    public bool cheeredMartin;

    public bool hasFlowers;
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

    public bool hasDecorations;
    public bool hiredBard;

    public int sweets;


    string costume;

    PlayerController pc;


    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
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

    public bool CheckGameCompletion()
    {
        if (hasDecorations && hiredBard)
        {
            if (hasCostume && sweets >= 2)
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
}
