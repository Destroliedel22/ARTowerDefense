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
        turretPlatform.SetActive(true);
        Instantiate(turretPrefab, turretPlatform.transform.position, Quaternion.identity);
    }
}