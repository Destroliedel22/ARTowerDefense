using UnityEngine;

public class PowerUp1PickUp : MonoBehaviour
{
    private HandCollision handCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (handCollision = collision.gameObject.GetComponentInParent<HandCollision>())
        {
            handCollision.ActivatePowerUp();
            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.powerUpActive);
        }
/*        if (collision.gameObject.layer == LayerMask.GetMask("Hands"))
        {
            //HandCollision.ActivatePowerUp();
            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.powerUpActive);
        }*/
    }
}