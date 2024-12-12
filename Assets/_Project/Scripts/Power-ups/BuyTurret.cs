using Oculus.Interaction;
using System.Transactions;
using UnityEngine;

public class BuyTurret : MonoBehaviour
{
    public GameObject turretPlatform;
    [SerializeField] private GameObject turretPrefab;

    [SerializeField] private GameObject powerupPrefab;

    private void Start()
    {
        turretPlatform.SetActive(false);
    }

    public void GetTurret()
    {
        // If player has enough money, then can get the power up
        if (CoinManager.Instance.currentMoney >= powerupPrefab.GetComponent<PowerUpData>().cost)
        {
            // Take the money
            CoinManager.Instance.RemoveCoin(powerupPrefab.GetComponent<PowerUpData>().cost);

            // Increase cost
            powerupPrefab.GetComponent<PowerUpData>().IncreaseCost();

            Vector3 spawnPos = new Vector3(turretPlatform.transform.position.x, turretPlatform.transform.position.y + 0.001f, turretPlatform.transform.position.z);
            turretPlatform.SetActive(true);
            Instantiate(turretPrefab, spawnPos, Quaternion.identity);
        }
    }
}