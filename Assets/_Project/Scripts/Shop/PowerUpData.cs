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
        coinText.text = cost.ToString() + " $";
    }

    // Increase the cost whenever you buy one in shop
    public void IncreaseCost()
    {
        if (cost > 100)
        {
            cost += 20;
        }
    }
}