using UnityEngine;
using UnityEngine.UI;
using System;
public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private HealthSystem healthSystem;

    private void Start()
    {
        UpdateHealthBar();
        healthSystem.OnHealthSystemHeal += HealthSystem_OnHealthSystemHeal;
        healthSystem.OnHealthSystemTakeDamage += HealthSystem_OnHealthSystemTakeDamage;
    }

    private void HealthSystem_OnHealthSystemHeal(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }

    private void HealthSystem_OnHealthSystemTakeDamage(object sender, EventArgs e)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = healthSystem.GetHealthNormalized();
    }
}
