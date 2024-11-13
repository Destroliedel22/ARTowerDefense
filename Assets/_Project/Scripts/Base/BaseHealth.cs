using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    // Health
    private float maxHealth = 10;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Death();
    }

    // If base does not have any health, it is game over
    private void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Play dying animation
            Destroy(gameObject);
            // Go to lose screen
        }
    }

    // Take damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }
}