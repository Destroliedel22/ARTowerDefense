using UnityEngine;

public class EnemyCollideWithHand : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.GetMask("Enemy"))
        {
            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.enemyHitWithHands);
        }
    }
}