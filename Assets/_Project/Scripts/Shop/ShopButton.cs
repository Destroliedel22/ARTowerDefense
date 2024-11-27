using UnityEngine;
using TMPro;

public class ShopButton : MonoBehaviour
{
    // Money display
    [SerializeField] private int cost;
    [SerializeField] private TextMeshProUGUI coinText;
    private bool isPayed = false;

    // Item reference
    [SerializeField] private GameObject item;

    // Cage reference
    [SerializeField] private GameObject cage;

    // Cooldown timer
    private float cooldown;

    private void Start()
    {
        // Display the cost per object
        coinText.text = cost.ToString() + " $";
    }

    private void CheckMoney()
    {
        if (CoinManager.Instance.currentMoney >= cost)
        {
            isPayed = true;
        }
    }

    // Place new item, turn cage back on
    private void ResetItem()
    {
        cage.SetActive(true);

        // Instantiate item
    }

    // When button is clicked take money
    public void PayOnClick()
    {
        // Check money when pressed
        CheckMoney();

        // Enable button
        if (isPayed)
        {
            CoinManager.Instance.RemoveCoin(cost);
            // Disable cage while item has not been taken
            cage.SetActive(false);
        }
        else
        {
            // Give feedback: cannot pay
        }
    }
}