using Oculus.Interaction;
using UnityEngine;

public class TutorialBuyTurret : MonoBehaviour
{
    public GameObject turretPlatform;
    private bool tutorialDone;
    [SerializeField] private GameObject tutotialTurretPrefab;
    [SerializeField] private GameObject turretPrefab;

    private void Start()
    {
        turretPlatform.SetActive(false);
    }

    public void GetTurret()
    {
        Vector3 spawnPos = new Vector3(turretPlatform.transform.position.x, turretPlatform.transform.position.y + 0.001f, turretPlatform.transform.position.z);
        turretPlatform.SetActive(true);
        if(tutorialDone)
        {
            Instantiate(turretPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Instantiate(tutotialTurretPrefab, spawnPos, Quaternion.identity);
        }
    }
}
