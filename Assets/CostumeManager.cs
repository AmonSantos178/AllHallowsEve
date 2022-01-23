using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeManager : MonoBehaviour
{
    [SerializeField] Sprite[] costumeImages;
    SpriteRenderer renderer;
    int currentCostume;
    Rigidbody2D rb;
    [SerializeField] Text infobarText;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject[] costumes;
    Image buttonImage;

    GameObject equippedCostume;
    GameObject previousCostume;
    Sprite currentCostumeIcon;
    Sprite previousCostumeIcon;
    PlayerController pc;
    bool walking;
    int i;

    void Start()
    {
        i = 0;
        pc = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        currentCostumeIcon = costumeImages[0];
        previousCostumeIcon = currentCostumeIcon;
        walking = false;
        currentCostume = 0;
        renderer = GetComponentInChildren<SpriteRenderer>();
        equippedCostume = costumes[0];
        previousCostume = equippedCostume;
        foreach (Button button in buttons)
        {
            buttonImage = buttons[i].GetComponent<Image>();
            buttonImage.sprite = costumeImages[i+1];
            //button.gameObject.SetActive(false);
            i++;
        }
    }

    bool IsWalking()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            infobarText.text = "I can't change costumes while walking. I'm not that agile.";
            return true;
        }
        else
        {
            renderer.sprite = costumeImages[currentCostume + 1];
            return false;
        }
    }

    void ButtonBehaviour(int index)
    {
        walking = IsWalking();
        if (!walking)
        {
            previousCostume = equippedCostume;
            equippedCostume = costumes[index];
            costumes[index] = previousCostume;
            costumes[0] = equippedCostume;
            previousCostume.SetActive(false);
            equippedCostume.SetActive(true);
            previousCostumeIcon = currentCostumeIcon;
            buttonImage = buttons[index - 1].GetComponent<Image>();
            currentCostumeIcon = buttonImage.sprite;
            buttonImage.sprite = previousCostumeIcon;
            pc.ProcessTag(equippedCostume.gameObject.tag);
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
