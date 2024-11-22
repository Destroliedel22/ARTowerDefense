using UnityEngine;
using UnityEngine.UI;

public class BaseHPBar : MonoBehaviour
{
    private Slider slider;
    private BaseHealth health;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        health = FindFirstObjectByType<BaseHealth>();
    }

    private void Update()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        float value = health.currentHealth / health.maxHealth;
        slider.value = value;
    }
}