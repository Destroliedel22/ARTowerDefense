using UnityEngine;
using TMPro;

public class xShopButton : MonoBehaviour
{
    // Money display
    [SerializeField] private int cost;
    [SerializeField] private TextMeshProUGUI coinText;
    private bool isPayed = false;

    // Item & cage reference
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject cage;

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
        powerUp.SetActive(true);
        cage.SetActive(true);
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
            // Pick up effect
            powerUp.SetActive(false);
            // Disable cage while item has not been taken
            cage.SetActive(false);
        }
        else
        {
            // Give feedback: cannot pay
        }
    }
}