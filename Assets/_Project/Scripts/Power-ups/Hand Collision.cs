using System.Collections;
using UnityEngine;

public class HandCollision : MonoBehaviour
{
    private float waitTime = 20f;
    [SerializeField] private Transform[] handObjects;

    [SerializeField] private LayerMask handLayer;
    [SerializeField] private LayerMask defaultLayer;

    [SerializeField] private GameObject powerupPrefab;

    private void Start()
    {
        GetHandObjects();
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = LayerMask.GetMask("Hands");
        }
    }

    private void GetHandObjects()
    {
        handObjects = GetComponentsInChildren<Transform>();
    }

    private IEnumerator AbilityActiveTime()
    {
        yield return new WaitForSeconds(waitTime);
        DeactivateAbility();
    }

    private void DeactivateAbility()
    {
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.powerUpEnd);
        GetHandObjects();
        foreach (Transform t in handObjects)
        {
            t.gameObject.layer = LayerMask.NameToLayer("Hands");
        }
    }

    public void ActivatePowerUp()
    {
        // If player has enough money, then can get the power up
        if (CoinManager.Instance.currentMoney >= powerupPrefab.GetComponent<PowerUpData>().cost)
        {
            // Take the money
            CoinManager.Instance.RemoveCoin(powerupPrefab.GetComponent<PowerUpData>().cost);

            // Increase cost
            powerupPrefab.GetComponent<PowerUpData>().IncreaseCost();

            GetHandObjects();
            foreach (Transform t in handObjects)
            {
                t.gameObject.layer = defaultLayer - 1;
            }
            StartCoroutine(AbilityActiveTime());
        }
    }
}