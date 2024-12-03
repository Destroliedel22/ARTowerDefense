using UnityEngine;

public class ShopManager : MonoBehaviour
{
    #region Singleton
    private static ShopManager instance;

    public static ShopManager Instance
    {
        get
        {
            // Check if the instance is empty
            if (instance == null)
            {
                Debug.LogWarning("There is no instance of ShopManager");
            }
            // Return the instance
            return instance;
        }
    }

    private void Awake()
    {
        // Set the instance, so we can change it
        instance = this;
    }
    #endregion

    // Shorter reference
    private GetPowerUps getPowerUps;

    private void Start()
    {
        getPowerUps = GetPowerUps.Instance;
    }

    public void BuyPowerUp(int powerUp)
    {
        // If player has enough money, then can get the power up
        if (CoinManager.Instance.currentMoney >= getPowerUps.powerUpPrefabs[powerUp].GetComponent<PowerUpData>().cost)
        {
            // Get the first from the list
            getPowerUps.GetPowerUp(getPowerUps.powerUpPrefabs[powerUp], getPowerUps.cagePrefabs[powerUp]);
            int powerUpCost = getPowerUps.powerUpPrefabs[powerUp].GetComponent<PowerUpData>().cost;

            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.buyInShop);

            // Take the money
            CoinManager.Instance.RemoveCoin(powerUpCost);

            // Set inactive
            getPowerUps.ActivatePowerup(powerUp);
        }
        else
        {
            // Give feedback
        }
    }
}