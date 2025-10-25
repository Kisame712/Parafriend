using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    private HealthSystem healthSystem;
    private Animator enemyAnim;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        enemyAnim = GetComponent<Animator>();
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

    private void OnTurnOver_EnemyAttack(object sender, EventArgs e)
    {
        enemyAnim.SetTrigger("attack");
    }
}
