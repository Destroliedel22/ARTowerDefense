using UnityEngine;

public class ReachedBase : MonoBehaviour
{
    private Enemy1 enemy;

    // Change the bool if enemy is in range
    private void OnTriggerEnter(Collider collider)
    {
        if (enemy = collider.GetComponent<Enemy1>())
        {
            enemy.reachedBase = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (enemy = collider.GetComponent<Enemy1>())
        {
            enemy.reachedBase = false;
        }
    }
}