using UnityEngine;

public class TurretPlacedSFX : MonoBehaviour
{
    [SerializeField] private GameObject placeEffect;

    private void Start()
    {
        placeEffect.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.turretPlaced);
            placeEffect.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        placeEffect.SetActive(false);
    }
}