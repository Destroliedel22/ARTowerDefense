using System.Collections;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    // Health
    public float maxHealth = 40;
    public float currentHealth;

    // Damage
    [SerializeField] private GameObject damageEffect;
    [SerializeField] private Transform damagePosition;

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
            // Soundeffect
            AudioManager.Instance.PlaySFX(AudioManager.Instance.gameLost);
            StartCoroutine(WaitForDyingAnimation());
        }
    }

    private IEnumerator WaitForDyingAnimation()
    {
        // Play dying animation
        yield return new WaitForSeconds(5);
        GameManager.Instance.enemiesWon = true;
        Destroy(gameObject);
    }

    // Take damage
    public void TakeDamage(float amount)
    {
        // Soundeffect
        AudioManager.Instance.PlaySFX(AudioManager.Instance.baseDamage);
        Instantiate(damageEffect, damagePosition.position, Quaternion.identity);
        currentHealth -= amount;
    }
}