using UnityEngine;

public class RoomSphereCollision : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemies"))
        {
            other.GetComponent<Enemy>().DeathState();
            other.GetComponent<EnemyItemHolder>().enabled = false;
            CoinManager.Instance.AddCoin(1);
        }
        else if(other.CompareTag("Item"))
        {
            CoinManager.Instance.AddCoin(1);
            Destroy(other);
        }
    }
}
