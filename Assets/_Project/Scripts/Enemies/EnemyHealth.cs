using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Health
    private float maxHealth = 5;
    public float currentHealth;

    private void Start()
    {
        // Set health
        currentHealth = maxHealth;
    }

    // Take damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }
}