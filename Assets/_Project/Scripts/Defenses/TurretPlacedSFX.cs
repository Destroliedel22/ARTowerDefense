using UnityEngine;

public class TurretPlacedSFX : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.turretPlaced);
        }
    }
}