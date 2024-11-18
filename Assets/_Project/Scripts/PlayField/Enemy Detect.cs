using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemies"))
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }
}
