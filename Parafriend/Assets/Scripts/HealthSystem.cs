using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isFriend;

    private int maxHealth;

    public event EventHandler OnHealthSystemHeal;
    public event EventHandler OnHealthSystemTakeDamage;
    private void Awake()
    {
        maxHealth = health;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        OnHealthSystemTakeDamage?.Invoke(this, EventArgs.Empty);
        if(health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isFriend)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Destroy(gameObject);
            StartCoroutine(DelayBeforeSceneChange());
        }
    }

    public void Healing(int healAmount)
    {
        health += healAmount;
        OnHealthSystemHeal?.Invoke(this, EventArgs.Empty);
    }

    public float GetHealthNormalized()
    {
        return (float)health / maxHealth;
    }

    private IEnumerator DelayBeforeSceneChange()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
