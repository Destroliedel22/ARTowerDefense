using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private EnemyHealth enemyHealth;

    private void OnTriggerEnter(Collider collider)
    {
        if (enemyHealth = collider.GetComponent<EnemyHealth>())
        {
            enemyHealth.TakeDamage(1);
        }
    }
}