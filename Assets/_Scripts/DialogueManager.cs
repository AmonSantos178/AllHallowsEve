using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueLine[] startingLines;

    [SerializeField] Image backdrop;
    [SerializeField] Image characterSprite;

    [SerializeField] Text charLine;
    [SerializeField] Text charName;
    [SerializeField] Text firstOptionText;
    [SerializeField] Text secondOptionText;

    [SerializeField] GameObject buttonOne;
    [SerializeField] GameObject buttonTwo;

    [SerializeField] GameObject panel;

    [SerializeField] Animator anim;

    PlayerController pc;
    PlayerInventory pi;
    ClockManager cm;

    DialogueLine currentLine;
    TradeManager tm;
    InteractionManager im;
    public Item giftOne;
    public Item giftTwo;

    void Start()
    {
        cm = FindObjectOfType<ClockManager>();
        pc = FindObjectOfType<PlayerController>();
        pi = FindObjectOfType<PlayerInventory>();
        tm = FindObjectOfType<TradeManager>();
        im = FindObjectOfType<InteractionManager>();
        panel.SetActive(true);
        pc.canMove = false;
        cm.running = false;
        currentLine = GetStartingLine("Mayor1");
        ManageScene();
    }
    private void ManageScene()
    {
        StartCoroutine(BlinkButtons());
        charLine.text = currentLine.GetDialogue();
        charName.text = currentLine.GetCharacterName();
        firstOptionText.text = currentLine.GetOptionOne();
        secondOptionText.text = currentLine.GetOptionTwo();

        backdrop.sprite = currentLine.GetBackdrop();
        characterSprite.sprite = currentLine.GetCharacterSprite();
    }
    public void SetUpDialogue(string identifier)
    {
        anim.SetTrigger("Transition");
        StartCoroutine(TurnPanelOn(identifier));
        StartCoroutine(TransitionEntry());
    }
    IEnumerator TurnPanelOn(string identifier)
    {
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(true);
        pc.canMove = false;
        cm.running = false;
        currentLine = GetStartingLine(identifier);
        ManageScene();
    }

    IEnumerator TransitionExit()
    {
        yield return new WaitForSeconds(1.45f);
        panel.SetActive(false);
        pc.canMove = true;
        cm.running = true;
    }

    IEnumerator TransitionEntry()
    {
        yield return new WaitForSeconds(1.45f);
        panel.SetActive(true);
        pc.canMove = false;
        cm.running = false;
        buttonOne.SetActive(true);
        yield return new WaitForSeconds(1.55f);
    }
    DialogueLine GetStartingLine(string identifier)
    {
        switch (identifier)
        {
            case "Mayor1": return startingLines[0];
            case "Mayor2": return startingLines[1];
            case "Mayor3": return startingLines[2];
            case "Mayor4": return startingLines[3];
            case "Bard1": return startingLines[4];
            case "Bard2": return startingLines[5];
            case "Candy1": return startingLines[6];
            case "Decor1": return startingLines[7];
            case "Food1": return startingLines[8];
            case "Costum1": return startingLines[9];
            case "Emily1": return startingLines[10];
            case "Emily2": return startingLines[11];
            case "Farmer1": return startingLines[12];
            case "Fish1": return startingLines[13];
            case "Fish2": return startingLines[14];
            case "Fish3": return startingLines[15];
            case "Friend1": return startingLines[16];
            case "Friend2": return startingLines[17];
            case "Grave1": return startingLines[18];
            case "Grave2": return startingLines[19];
            case "Grave3": return startingLines[20];
            case "Mom1": return startingLines[21];
            case "Mom2": return startingLines[22];
            case "Willie1": return startingLines[23];
            case "Willie2": return startingLines[24];
            case "Willie3": return startingLines[25];
            case "Stan1": return startingLines[26];
            default: return startingLines[0];
        }
    }

    public string GetName()
    {
        return currentLine.GetCharacterName();
    }

    #region Button Management
    public void PressButtonOne()
    {
        if (currentLine.endsGame)
        {
            SceneManager.LoadScene(0);
        }
        else if (currentLine.isEndState)
        {
            anim.SetTrigger("Transition");
            StartCoroutine(TransitionExit());
            buttonOne.SetActive(false);
        }
        else
        {
            if (currentLine.isStore)
            {
                tm.SetUpShop();
            }
            var nextScene = currentLine.GetNextLines();
            currentLine = nextScene[0];
            ManageScene();
        }
    }

    public void PressButtonTwo()
    {
        var nextScene = currentLine.GetNextLines();
        if (currentLine.RequiresGold())
        {
            if (pi.GetPlayerGold() < currentLine.GoldRequired())
            {
                nextScene = currentLine.GetNextLines();
                currentLine = nextScene[2];
            }
            else
            {
                pi.ChangePlayerGold(-currentLine.GoldRequired());
                nextScene = currentLine.GetNextLines();
                currentLine = nextScene[1];
                im.hiredBard = true;
            }
        }
        else
        {
            if (currentLine.itemChange)
            {
                string npcName = currentLine.GetCharacterName();
                if (npcName == "Sam Astin")
                {
                    if (pi.playerCostumes.Count > 1)
                    {
                        List<Item> possibleCostumeChoices = pi.playerCostumes.FindAll(GetUnequippedCostumes);
                        if (possibleCostumeChoices.Count > 0)
                        {
                            pi.playerCostumes.Remove(possibleCostumeChoices[Random.Range(0, possibleCostumeChoices.Count)]);
                        }
                        else
                        {
                            pi.playerCostumes.Remove(pi.playerCostumes[0]);
                            pi.equippedCostume = pi.startingCostume;
                            pc.ProcessTag(pi.equippedCostume.GetCostumeIndex());
                        }
                    }
                }
                else if (npcName == "Stan Mason")
                {
                    pi.ChangePlayerGold(30);
                    pi.playerItems.Add(giftOne);
                    pi.playerItems.Add(giftTwo);
                }
            }
            currentLine = nextScene[1];
        }
        ManageScene();
    }

    public bool GetUnequippedCostumes(Item item)
    {
        if (item.IsAdmissible())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ActivateButtonOne()
    {
        buttonOne.SetActive(true);
    }

    IEnumerator BlinkButtons()
    {
        buttonOne.SetActive(false);
        buttonTwo.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        buttonOne.SetActive(true);
        if (currentLine.twoButton)
        {
            buttonTwo.SetActive(true);
        }
        #endregion
    }
}
