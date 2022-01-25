using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CostumeManager : MonoBehaviour
{
    SpriteRenderer renderer;
    int currentCostume;
    Rigidbody2D rb;
    [SerializeField] Text infobarText;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject[] costumes;
    [SerializeField] Item startingCostume;
    //Item[] playerCostumes /*= new Item[6]*/;
    List<Item> playerCostumes = new List<Item>() /*= new Item[6]*/;
    Image buttonImage;
    

    Item equippedCostume;
    Item previousCostume;
    Sprite currentCostumeIcon;
    PlayerController pc;
    bool walking;
    int i;

    void Start()
    {
        i = 0;
        pc = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        currentCostumeIcon = startingCostume.GetIcon();
        walking = false;
        currentCostume = startingCostume.GetCostumeIndex();
        renderer = GetComponentInChildren<SpriteRenderer>();
        playerCostumes.Add(startingCostume);
        //playerCostumes[0] = startingCostume;
        equippedCostume = startingCostume;
        previousCostume = equippedCostume;
        /* foreach (Button button in buttons)
         {
             button.gameObject.SetActive(false);
             i++;
         }*/
    }

    void ButtonBehaviour(int index)
    {
        walking = pc.GetWalking();
        if (!walking)
        {
            previousCostume = equippedCostume;
            equippedCostume = playerCostumes[index];
            playerCostumes[index] = previousCostume;
            buttonImage = buttons[index - 1].GetComponent<Image>();
            buttonImage.sprite = playerCostumes[index].GetIcon();
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

    public void AddCostume(Item item)
    {
        int position = playerCostumes.Count;
        playerCostumes.Add(item);
        buttonImage = buttons[position - 1].GetComponent<Image>();
        buttonImage.sprite = playerCostumes[position].GetIcon();
    }

    /*public void RemoveCostume(Item item)
    {
        i = 0;
        int position = System.Array.IndexOf(playerCostumes, item);
        foreach (Item it in playerCostumes)
        {
            if (i <= position) return;
            else playerCostumes[i - 1] = it;
            buttonImage = buttons[i].GetComponent<Image>();
            buttonImage.sprite = playerCostumes[i + 1].GetIcon();
            i++;
        }
    }*/

    int ProcessCostume(Item a)
    {
        string costumeName = a.GetName();
        switch (costumeName)
        {
            case "Base": return 0;
            case "Pirate Costume": return 1;
            case "Wizard Costume": return 2;
            case "Vampire Costume": return 3;
            case "Grim Reaper Costume": return 4;
            case "Fish-Monster Costume": return 5;
            default: return 0;
        }
    }

    public List<Item> GetPlayerCostumes()
    {
        return playerCostumes;
    }

}
