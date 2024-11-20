using UnityEngine;

public class RoomCollision : MonoBehaviour
{
    //enemy dies when hitting room collider
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemies"))
        {
            collision.gameObject.GetComponent<Enemy>().DeathState();
        }
    }
}
