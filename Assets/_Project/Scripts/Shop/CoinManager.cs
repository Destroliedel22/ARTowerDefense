using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    #region Singleton
    private static CoinManager instance;
    public static CoinManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("There is no instance of CoinManager");
            }
            // Return the private instance
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private TextMeshProUGUI coinText;
    public int currentMoney = 0;

    private void Start()
    {
        coinText.text = currentMoney.ToString() + " $";
    }

    // Call function when getting money
    public void AddCoin(int amount)
    {
        currentMoney += amount;
        coinText.text = currentMoney.ToString() + " $";
    }

    // Call function when spending money
    public void RemoveCoin(int amount)
    {
        currentMoney -= amount;
        coinText.text = currentMoney.ToString() + " $";

        // Can't go below 0
        if (currentMoney <= 0)
        {
            currentMoney = 0;
        }
    }
}