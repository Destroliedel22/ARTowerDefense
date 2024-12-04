using UnityEngine;

public class PowerUp1PickUp : MonoBehaviour
{
    private HandCollision handCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (handCollision = collision.gameObject.GetComponentInParent<HandCollision>())
        {
            handCollision.ActivatePowerUp();
        }
/*        if (collision.gameObject.layer == LayerMask.GetMask("Hands"))
        {
            //HandCollision.ActivatePowerUp();
        }*/
    }
}