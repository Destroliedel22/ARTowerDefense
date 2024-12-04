using UnityEngine;

public class CrystalPickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.GetMask("Hands"))
        {
            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectLoot);
            CoinManager.Instance.AddCoin(1);
            Destroy(gameObject);
        }
    }
}