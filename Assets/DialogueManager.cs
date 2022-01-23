using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueLine startingLine;

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
        currentLine = startingLine;
        ManageScene();
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

    public void PanelOn(bool on)
    {
        panel.SetActive(on);
    }

    void StartingStates(string identifier)
    {
        switch(identifier)
        {
            default: return;
        }
    }

    #region Button Management
    public void PressButtonOne()
    {
        if (currentLine.isEndState)
        {
            PanelOn(false);
        }
        else
        {
            var nextScene = currentLine.GetNextLines();
            currentLine = nextScene[0];
            ManageScene();
        }
    }

    public void PressButtonTwo()
    {
        var nextScene = currentLine.GetNextLines();
        currentLine = nextScene[1];
        ManageScene();
    }
    #endregion
}
