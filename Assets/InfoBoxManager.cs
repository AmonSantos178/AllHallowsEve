using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoBoxManager : MonoBehaviour
{
    [SerializeField] Text infoBarText;
    float interactionDistance = 10f;

    void Start()
    {
        infoBarText.text = "This is your information bar. Right-Click something to learn about it!";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                float distance = CheckDistance(new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y));
                if(distance >= interactionDistance)
                {
                    infoBarText.text = "That's too far away for me to interact. I should get closer.";
                }
                else
                {
                    infoBarText.text = "I have interacted with " + hit.collider.gameObject.tag;
                }
            }
            else
            {
                infoBarText.text = "I cannot interact with this.";
            }

        }

        else if (Input.GetMouseButtonDown(1))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                infoBarText.text = GetInformation(hit.collider.gameObject.tag);
            }
            else
            {
                infoBarText.text = "This is the ground. This is where I walk.";
            }

        }
    }

    float CheckDistance(Vector2 location)
    {
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Debug.Log(Vector2.Distance(playerPosition, location));
        return Vector2.Distance(playerPosition, location);
    }

    string GetInformation(string tag)
    {
        switch (tag)
        {
            case "Bard": return "This is the Bard's House, the music he's playing gives it away.";
            case "Tesker": return "This is the Tesker household. Mr. Tesker, the fisherman, lives here with his daughter.";
            case "Hobbit": return "Martin Holm, the author, lives here. He does not appreciate visitors.";
            case "Candy": return "Lady Hershell sells the best sweets in the province. I wonder where she gets them.";
            case "Costume": return "The mayor's wife, Lady Helen, works here selling clothes. She is not fond of me.";
            case "Decor": return "Sweet Rosalyn works here, selling decorations. I often swing by to chat.";
            case "Fisherman": return "This is Old Mr. Tesker, our fisherman. He's grumpy, but he's a good man.";
            case "Food": return "This is Ms. Nicole's Food stand. Everything always looks so appetizing.";
            case "Mayor": return "Mayor Linday's house. Both him and his wife are at work, I doubt there's anyone here.";
            case "Grave": return "The Gravedigger's home. I shouldn't bother him, he's always jumpy on Halloween.";
            case "Hall": return "The town hall. Mayor Lindsay told me not to return here until everything is done.";
            case "Mom": return "That's my house. I'm pretty sure mom's home, maybe she can help.";
            case "Friend": return "That's Sam's house. He's my best friend ever since we were little.";
            case "Stan": return "Stan's house. He's a bit weird, but certainly the smartest guy in the village.";
            case "Willy": return "Old Willie's house. He always cracks me up, but I doubt he's awake right now.";
            case "Empty": return "This house has been empty for years. The only things inside are racoons and spiders.";
            case "Farm": return "Mr. Holm's Farm. His nephew takes care of it, mostly, but he's away on a journey.";
            case "Graveyard": return "This is our graveyard. This place is going to be full of drunks tonight, I'm sure.";
            case "Barrier": return "There is nothing for me that way. I'm not the adventurous type.";
            case "Water": return "There's usually plenty of fish in these waters, but today they're strangely calm.";
            default: return "There is nothing noteworthy about this.";
        }
    }

    void ProcessInteraction(string tag)
    {
        switch (tag)
        {
            case "Bard": return "This is the Bard's House, the music he's playing gives it away.";
            case "Tesker": return "This is the Tesker household. Mr. Tesker, the fisherman, lives here with his daughter.";
            case "Hobbit": return "Martin Holm, the author, lives here. He does not appreciate visitors.";
            case "Candy": return "Lady Hershell sells the best sweets in the province. I wonder where she gets them.";
            case "Costume": return "The mayor's wife, Lady Helen, works here selling clothes. She is not fond of me.";
            case "Decor": return "Sweet Rosalyn works here, selling decorations. I often swing by to chat.";
            case "Fisherman": return "This is Old Mr. Tesker, our fisherman. He's grumpy, but he's a good man.";
            case "Food": return "This is Ms. Nicole's Food stand. Everything always looks so appetizing.";
            case "Mayor": return "Mayor Linday's house. Both him and his wife are at work, I doubt there's anyone here.";
            case "Grave": return "The Gravedigger's home. I shouldn't bother him, he's always jumpy on Halloween.";
            case "Hall": return "The town hall. Mayor Lindsay told me not to return here until everything is done.";
            case "Mom": return "That's my house. I'm pretty sure mom's home, maybe she can help.";
            case "Friend": return "That's Sam's house. He's my best friend ever since we were little.";
            case "Stan": return "Stan's house. He's a bit weird, but certainly the smartest guy in the village.";
            case "Willy": return "Old Willie's house. He always cracks me up, but I doubt he's awake right now.";
            case "Empty": return "This house has been empty for years. The only things inside are racoons and spiders.";
            case "Farm": return "Mr. Holm's Farm. His nephew takes care of it, mostly, but he's away on a journey.";
            case "Graveyard": return "This is our graveyard. This place is going to be full of drunks tonight, I'm sure.";
            case "Barrier": infoBarText.text = "If I take one more step, it'll be the farthest away from home I've ever been."; return;
            case "Water": infoBarText.text = "Sorry, I can't swim. And I don't feel like learning the hard way."; return;
            default: return;
        }
    }

    void CheckIfScared(string tag)
    {

    }
}
