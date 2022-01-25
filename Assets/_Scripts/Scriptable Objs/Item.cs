using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    #region Properties
    [SerializeField] Sprite itemIcon;

    [SerializeField] string itemName;
    [SerializeField] int costumeIndex;

    [SerializeField] ItemType itemType;

    [SerializeField] int buyPrice;
    [SerializeField] int sellPrice;
    [SerializeField] bool isAdmissible;
    [SerializeField] bool isGift;
    public bool isEquiped;
    #endregion
    #region Return Methods
    public Sprite GetIcon()
    {
        return itemIcon;
    }

    public string GetName()
    {
        return itemName;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public int GetBuyPrice()
    {
        return buyPrice;
    }

    public int GetSellPrice()
    {
        return sellPrice;
    }

    public bool IsAdmissible()
    {
        return isAdmissible;
    }
    public bool IsGift()
    {
        return isGift;
    }

    public int GetCostumeIndex()
    {
        return costumeIndex;
    }
    #endregion
}
