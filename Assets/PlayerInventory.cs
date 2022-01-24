using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] Image[] inventorySlotImages;
    [SerializeField] Text goldText;
    [SerializeField] int startingGold;
    int playerGold;
    void Start()
    {
        playerGold = startingGold;
        goldText.text = playerGold.ToString();
    }

    void Update()
    {

    }

    public int GetPlayerGold()
    {
        return playerGold;
    }

    public void ChangePlayerGold(int amount)
    {
        playerGold += amount;
        goldText.text = playerGold.ToString();
    }
}
