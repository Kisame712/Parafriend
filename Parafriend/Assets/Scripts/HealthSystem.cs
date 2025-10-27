using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isFriend;
    [SerializeField] private GameObject visuals;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private AudioClip enemyDeadSound;
    [SerializeField] private GameObject bloodParticles;
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
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
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
            EffectSoundManager.Instance.PlaySoundEffect(enemyDeadSound);
            visuals.SetActive(false);
            healthBar.SetActive(false);
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
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
