using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    bool scaredTesker;
    bool scaredDermot;
    bool cheeredWillie;
    bool cheeredMartin;

    bool hasEggs;
    bool hasFlowers;
    bool hasLunch;
    bool hasCostume;
    bool hasCandles;
    bool hasMilk;
    bool hasFishySticks;
    bool hasGifts;

    bool hasDecorations;
    bool hiredBard;

    int sweets;


    string costume;

    PlayerController pc;


    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        
    }
}
