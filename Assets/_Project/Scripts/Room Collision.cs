using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            collision.gameObject.GetComponent<Enemy>().DeathState();
        }
    }
}
