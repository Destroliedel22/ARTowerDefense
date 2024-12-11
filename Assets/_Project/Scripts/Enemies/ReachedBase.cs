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
            // Kill enemy after 2 seconds
            Destroy(enemy.gameObject, 1);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (enemy = collider.GetComponent<Enemy>())
        {
            enemy.reachedBase = false;
        }
    }
}