using UnityEngine;

public class TurretShopTrigger : MonoBehaviour
{
    private BuyTurret buyTurret;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.GetMask("Hands"))
        {
            buyTurret.turretPlatform.SetActive(false);
        }
    }
}