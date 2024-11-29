using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GetPowerUps : MonoBehaviour
{
    // The selected power up and cage (the one purchased on click)
    private GameObject selectedPowerUp;
    private GameObject selectedCage;

    // Item & cage reference
    public List<GameObject> powerUpPrefabs = new List<GameObject>();
    public List<GameObject> cagePrefabs = new List<GameObject>();

    #region Singleton
    private static GetPowerUps instance;

    public static GetPowerUps Instance
    {
        get
        {
            // Check if the instance is empty
            if (instance == null)
            {
                Debug.LogWarning("There is no instance of GetPowerUps");
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

    // Turn it back on after cooldown is done
    private IEnumerator CooldownTimer(int powerUp, int cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        powerUpPrefabs[powerUp].SetActive(true);
        cagePrefabs[powerUp].SetActive(true);
    }

    // Have this be the reference to change the active power up
    public GameObject GetActivePowerUp()
    {
        return selectedPowerUp;
    }

    public GameObject GetSelectedCage()
    {
        return selectedCage;
    }

    // Reference the prefabs
    public void GetPowerUp(GameObject powerUp, GameObject cage)
    {
        selectedPowerUp = powerUp;
        selectedCage = cage;
    }

    // Remove the cage so the player can grab the powerup
    public void ActivatePowerup(int powerUp)
    {
        //powerUpPrefabs[powerUp].SetActive(false);
        cagePrefabs[powerUp].SetActive(false);

        StartCoroutine(CooldownTimer(powerUp, 5));
    }
}