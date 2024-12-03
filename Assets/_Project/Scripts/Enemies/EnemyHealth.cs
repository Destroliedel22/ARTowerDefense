using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Damage
    [SerializeField] private GameObject damageTextPrefab;

    // Health
    private float maxHealth = 5;
    public float currentHealth;

    private void Start()
    {
        // Set health
        currentHealth = maxHealth;
    }

    // Instantiate the amount of damage it takes
    private void ShowDamage(string text)
    {
        if (damageTextPrefab)
        {
            GameObject damagePrefab = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);
            damagePrefab.GetComponentInChildren<TextMeshPro>().text = text;
        }
    }

    // Take damage
    public void TakeDamage(float amount)
    {
        ShowDamage("-" + amount.ToString());
        currentHealth -= amount;
    }
}