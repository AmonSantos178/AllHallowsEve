using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueLine[] startingLines;

    [SerializeField] Image backdrop;
    [SerializeField] Image characterSprite;

    [SerializeField] Text charLine;
    [SerializeField] Text charName;
    [SerializeField] Text firstOptionText;
    [SerializeField] Text secondOptionText;

    [SerializeField] GameObject buttonTwo;

    [SerializeField] GameObject panel;


    DialogueLine currentLine;
    void Start()
    {
        SetUpDialogue("Mayor1");
    }

    private void ManageScene()
    {
        charLine.text = currentLine.GetDialogue();
        charName.text = currentLine.GetCharacterName();
        firstOptionText.text = currentLine.GetOptionOne();
        secondOptionText.text = currentLine.GetOptionTwo();

        backdrop.sprite = currentLine.GetBackdrop();
        characterSprite.sprite = currentLine.GetCharacterSprite();

        if (!currentLine.twoButton)
        {
            buttonTwo.SetActive(false);
        }
        else buttonTwo.SetActive(true);
    }
    public void SetUpDialogue(string identifier)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        currentLine = GetStartingLine(identifier);
        ManageScene();
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

    #region Button Management
    public void PressButtonOne()
    {
        if (currentLine.isStore)
        {
            /*open sell menu*/
        }
        else
        {
            if (currentLine.endsGame)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
            }
            else if (currentLine.isEndState)
            {
                Time.timeScale = 1f;
                panel.SetActive(false);
            }
            else
            {
                var nextScene = currentLine.GetNextLines();
                currentLine = nextScene[0];
                ManageScene();
            }
        }
    }

    public void PressButtonTwo()
    {
        if (currentLine.isStore)
        {
            /*open buy menu*/
        }
        else
        {
            var nextScene = currentLine.GetNextLines();
            currentLine = nextScene[1];
            ManageScene();
        }
    }
    #endregion
}
