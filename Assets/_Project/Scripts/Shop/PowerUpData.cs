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
}