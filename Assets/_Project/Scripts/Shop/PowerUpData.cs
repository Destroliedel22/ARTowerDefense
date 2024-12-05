using TMPro;
using UnityEngine;

public class PowerUpData : MonoBehaviour
{
    // Money display
    [SerializeField] private TextMeshProUGUI coinText;
    public int cost;

    private void Start()
    {
        // Display the cost per object
        UpdateMoney();
    }

    private void UpdateMoney()
    {
        coinText.text = cost.ToString() + " $";
    }

    // Increase the cost whenever you buy one in shop
    public void IncreaseCost()
    {
        // Update the text
        UpdateMoney();

        if (cost < 100)
        {
            cost += 20;
        }
    }
}