using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfoBoxManager : MonoBehaviour
{
    [SerializeField] Text infoBarText;
    [SerializeField] Image list;
    float interactionDistance = 10f;
    InteractionManager im;
    PlayerController pc;
    DialogueManager dm;
    [SerializeField] GameObject fisherman;

    void Start()
    {
        infoBarText.text = "This is your information bar. Right-Click something to learn about it!";
        list.gameObject.SetActive(false);
        im = FindObjectOfType<InteractionManager>();
        pc = FindObjectOfType<PlayerController>();
        dm = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            interactionDistance = 10f;
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                Vector2 hitLocation = new Vector2(hit.collider.gameObject.transform.position.x, hit.collider.gameObject.transform.position.y);
                float distance = CheckDistance(hitLocation, hit.collider.bounds.size.x);
                if (distance >= interactionDistance)
                {
                    infoBarText.text = "That's too far away for me to interact. I should get closer.";
                }
                else
                {
                    //infoBarText.text = "I have interacted with " + hit.collider.gameObject.tag;
                    ProcessInteraction(hit.collider.gameObject.tag);
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            list.gameObject.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            list.gameObject.SetActive(false);
        }
    }

    float CheckDistance(Vector2 location, float sizeX)
    {
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Debug.Log(Vector2.Distance(playerPosition, location));
        interactionDistance = Mathf.Clamp((interactionDistance * sizeX) / 13f, 5f, 100f);
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
            case "Bard":
                if (im.hiredBard)
                {
                    infoBarText.text = "Looks like he's already left home to go play at the party. Great, one less worry!"; return;
                }
                else if (im.hasFlowers)
                {
                    im.hiredBard = true;
                    return;
                }
                else return;
            case "Tesker":
                if (im.stanQuest)
                {
                    infoBarText.text = "Emily isn't answering the door. Perhaps Stan's gift worked..."; return;
                }
                else if (im.hasGifts)
                {
                    im.hasGifts = false;
                    /*dialogue*/
                    return;
                }
                else if (im.emilyQuest)
                {
                    infoBarText.text = "Emily isn't answering the door. Maybe she's not home."; return;
                }
                else if (im.hasLunch)
                {
                    infoBarText.text = "I should deliver her father's lunch before I talk to Emily Again"; return;
                }
                else return;
            case "Hobbit":
                if (im.cheeredMartin)
                {
                    infoBarText.text = "Looks like he's left his house for his final adventure."; return;
                }
                else if (pc.CheckTag() == "C2")
                {
                    im.cheeredMartin = true;
                    return;
                }
                else
                {
                    infoBarText.text = "'No, thank you! I don't want any more visitors, well-wishers or distant relations!'"; return;
                }
            case "Candy": return;
            case "Costume": return;
            case "Decor": return;
            case "Fisherman":
                if (pc.CheckTag() == "C5")
                { 
                    /*dialogue*/
                    Destroy(fisherman.gameObject);
                    return;
                }
                else if (im.hasLunch)
                {
                    /*dialogue*/
                    im.emilyQuest = true;
                    return;
                }
                else return;
            case "Food": return;
            case "Mayor": infoBarText.text = "No one answered the door. They seem to be both at work."; return;
            case "Grave":
                if (im.scaredDermot)
                {
                    infoBarText.text = "Looks like he won't open the door. I must have really scared him.";
                    return;
                }
                else if (pc.CheckTag() == "C4")
                {
                    im.scaredDermot = true;
                    return;
                }
                else if (im.hasCandles)
                {
                    im.gravediggerQuest = true;
                    return;
                }
                else return;
            case "Hall":
                if (im.CheckGameCompletion() == true)
                {
                    return;
                }
                else
                {
                    return;
                }
            case "Mom":
                if (im.momQuest)
                {
                    infoBarText.text = "No answer. Maybe she left to go egg some houses.";
                    return;
                }
                else if (im.hasEggs)
                {
                    im.momQuest = true;
                    return;
                }
                else return;
            case "Friend":
                if (im.friendQuest)
                {
                    infoBarText.text = "No answer. Perhaps he left home early for the party. I'll see him there later.";
                    return;
                }
                else if (im.hasCostume)
                {
                    im.friendQuest = true;
                    return;
                }
                else return;
            case "Stan":
                if (im.stanQuest)
                {
                    infoBarText.text = "Guess he went after Emily. Maybe this time things will work out between them.";
                    return;
                }
                else if (im.hasGifts)
                {
                    infoBarText.text = "I should deliver the gifts before I talk to Stan again.";
                    return;
                }
                else return;
            case "Willy":
                if (im.cheeredWillie)
                {
                    infoBarText.text = "Let him rest. He's a good man with a heart of gold.";
                    return;
                }
                else if (pc.CheckTag() == "C1")
                {
                    im.cheeredWillie = true;
                    return;
                }
                else if (im.hasFishySticks)
                {
                    im.gravediggerQuest = true;
                    return;
                }
                else return;

            case "Empty": infoBarText.text = "I knock, but hear no one. It's probably best to stay away from here."; return;
            case "Farm": infoBarText.text = "I shouldn't mess with Mr. Holm's farm. I hear he has some powerful friends."; return;
            case "Graveyard": infoBarText.text = "I'm not digging in there. YOU dig in there. I refuse."; return;
            case "Barrier": infoBarText.text = "If I take one more step, it'll be the farthest away from home I've ever been."; return;
            case "Water": infoBarText.text = "Sorry, I can't swim, and I don't feel like learning the hard way."; return;
            default: return;
        }
    }
}
