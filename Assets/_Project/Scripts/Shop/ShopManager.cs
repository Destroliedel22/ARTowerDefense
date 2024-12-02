using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    // Keep track if the powerups are activated
    // Activate timer

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

    // Item & cage references
    public List<GameObject> powerUps = new List<GameObject>();
    public List<GameObject> cages = new List<GameObject>();

    // Cooldown timer
    private float cooldown;

    private void UpdatePowerUps()
    {

    }

    private void CheckTimer()
    {

    }
}