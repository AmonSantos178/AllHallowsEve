using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue Line")]
public class DialogueLine : ScriptableObject
{
    [TextArea(10, 30)] [SerializeField] string dialogue;
    [SerializeField] string characterName;
    [SerializeField] string optionOne;
    [SerializeField] string optionTwo;
    [SerializeField] string itemName;

    public bool twoButton = false;
    public bool isEndState = false;
    public bool endsGame = false;
    public bool isStore = false;
    public bool itemChange = false;

    [SerializeField] DialogueLine[] nextScenes;
    [SerializeField] Sprite backdrop;
    [SerializeField] Sprite characterSprite;

    #region Return Methods
    public string GetDialogue()
    {
        return dialogue;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public string GetOptionOne()
    {
        return optionOne;
    }

    public string GetOptionTwo()
    {
        return optionTwo;
    }

    public Sprite GetBackdrop()
    {
        return backdrop;
    }
    public Sprite GetCharacterSprite()
    {
        return characterSprite;
    }

    public DialogueLine[] GetNextLines()
    {
        return nextScenes;
    }

    #endregion
}
