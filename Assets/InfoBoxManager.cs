using UnityEngine;
using UnityEngine.UI;

public class InfoBoxManager : MonoBehaviour
{
    [SerializeField] Text infoBarText;
    float infobarTimer;
    float infobarDuration = 12;

    // Start is called before the first frame update
    void Start()
    {
        infoBarText.text = "This is your information bar. Click something to learn about it!";
        infobarTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                infoBarText.text = GetInformation(hit.collider.gameObject.tag);
                Debug.Log(hit.collider.gameObject.tag);
                infobarTimer = 0;
            }
            else
            {
                infoBarText.text = "";
            }

        }
    }
    void FixedUpdate()
    {
        infobarTimer += Time.deltaTime;

        if (infobarTimer >= infobarDuration)
        {
            infoBarText.text = "";
        }
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
            case "Hall": return "The town hall. Mayor Lindsay told me not to return until everything is done.";
            case "Mom": return "That's my house. I'm pretty sure mom's home, maybe she can help.";
            case "Friend": return "That's Sam's house. He's my best friend ever since we were little.";
            case "Stan": return "Stan's house. He's a bit weird, but certainly the smartest guy in the village.";
            case "Willy": return "Old Willie's house. He always cracks me up, but I doubt he's awake right now.";
            case "Empty": return "This house has been empty for years. The only things inside are racoons and spiders.";
            case "Farm": return "Mr. Holm's Farm. His nephew takes care of it, mostly, but he's away on a journey.";
            case "Graveyard": return "This is our graveyard. This place is going to be full of drunks tonight, I'm sure.";
            default: return "There is nothing noteworthy about this.";
        }
    }
}
