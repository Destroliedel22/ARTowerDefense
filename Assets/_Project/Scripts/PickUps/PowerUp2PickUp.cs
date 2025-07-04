using System.Collections;
using UnityEngine;

public class PowerUp2PickUp : MonoBehaviour
{
    [SerializeField] private GameObject turretCol1;
    [SerializeField] private GameObject turretCol2;

    private void Start()
    {
        turretCol1.SetActive(false);
        turretCol2.SetActive(false);
    }

    public void ActivateTurretColliders()
    {
        StartCoroutine(TurnCollidersOn());
    }

    private IEnumerator TurnCollidersOn()
    {
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.powerUpActive);
        turretCol1.SetActive(true);
        turretCol2.SetActive(true);
        yield return new WaitForSeconds(20);
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.powerUpEnd);
        turretCol1.SetActive(false);
        turretCol2.SetActive(false);
    }
}