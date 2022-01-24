using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    #region Properties
    [SerializeField] Sprite itemIcon;

    [SerializeField] string itemName;
    [SerializeField] ItemType itemType;

    [SerializeField] int buyPrice;
    [SerializeField] int sellPrice;
    [SerializeField] bool isAdmissible;
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
    #endregion
}
