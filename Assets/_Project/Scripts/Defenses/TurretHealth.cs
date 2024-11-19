using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    // Health
    private float maxHealth = 5;
    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        Death();
    }

    // If turret does not have any health, destroy it
    private void Death()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }
    }

    // Take damage
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }
}