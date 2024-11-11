using UnityEngine;

public class TurretPlacement : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Defense"))
        {
            //collision.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }
}
