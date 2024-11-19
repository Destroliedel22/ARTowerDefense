using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemies"))
        {
            collision.gameObject.transform.SetParent(this.transform);
            Physics.gravity = new Vector3(gameObject.transform.up.x, gameObject.transform.up.y * -1, gameObject.transform.up.z);
        }
    }
}
