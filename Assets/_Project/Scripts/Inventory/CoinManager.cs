using UnityEngine;

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

    // Player starts with x amount of money
    [SerializeField] private int currentMoney = 5;

    // Call function when getting money
    public void AddCoin(int amount)
    {
        currentMoney += amount;
    }

    // Call function when spending money
    public void RemoveCoin(int amount)
    {
        currentMoney -= amount;

        // Can't go below 0
        if (currentMoney <= 0)
        {
            currentMoney = 0;
        }
    }
}