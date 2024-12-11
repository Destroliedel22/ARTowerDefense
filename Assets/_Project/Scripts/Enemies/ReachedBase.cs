using UnityEngine;

public class ReachedBase : MonoBehaviour
{
    private Enemy enemy;

    // Change the bool if enemy is in range
    private void OnTriggerEnter(Collider collider)
    {
        if (enemy = collider.GetComponent<Enemy>())
        {
            enemy.reachedBase = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (enemy = collider.GetComponent<Enemy>())
        {
            enemy.reachedBase = false;
            // Kill enemy after 2 seconds
            Destroy(enemy.gameObject, 2);
        }
    }
}