using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    //sets enemy gravity towards the platform
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemies"))
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
