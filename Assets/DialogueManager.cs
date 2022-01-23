using System.Collections;
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

    [SerializeField] GameObject buttonTwo;

    [SerializeField] GameObject panel;

    [SerializeField] Animator anim;


    DialogueLine currentLine;
    void Start()
    {
        panel.SetActive(true);
        currentLine = GetStartingLine("Mayor1");
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
        currentLine = GetStartingLine(identifier);
        ManageScene();
    }

    IEnumerator TransitionExit()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1.45f);
        panel.SetActive(false);
    }

    IEnumerator TransitionEntry()
    {
        yield return new WaitForSeconds(1.45f);
        panel.SetActive(true);
        yield return new WaitForSeconds(1.55f);
        Time.timeScale = 0;
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
        if (currentLine.endsGame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
        else if (currentLine.isEndState)
        {
            Time.timeScale = 1f;
            anim.SetTrigger("Transition");
            StartCoroutine(TransitionExit());
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
        if (currentLine.isStore)
        {
            /*open buy menu*/
        }
        if (currentLine.itemChange)
        {
            //costume
            //gold(bard)
            //gifts
        }
        var nextScene = currentLine.GetNextLines();
        currentLine = nextScene[1];
        ManageScene();
    }
    #endregion
}
