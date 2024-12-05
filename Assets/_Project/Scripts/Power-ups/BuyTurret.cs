using Oculus.Interaction;
using System.Transactions;
using UnityEngine;

public class BuyTurret : MonoBehaviour
{
    public GameObject turretPlatform;
    [SerializeField] private GameObject turretPrefab;

    private void Start()
    {
        turretPlatform.SetActive(false);
    }

    public void GetTurret()
    {
        Vector3 spawnPos = new Vector3(turretPlatform.transform.position.x, turretPlatform.transform.position.y + 0.001f, turretPlatform.transform.position.z);
        turretPlatform.SetActive(true);
        Instantiate(turretPrefab, spawnPos, Quaternion.identity);
    }
}