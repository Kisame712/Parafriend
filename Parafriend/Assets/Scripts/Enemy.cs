using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform stonePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private AudioClip enemyAttackSound;
    private HealthSystem healthSystem;
    private Animator enemyAnim;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        enemyAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        TurnSystem.Instance.OnTurnOver += OnTurnOver_EnemyAttack;
    }

    private void OnDestroy()
    {
        TurnSystem.Instance.OnTurnOver -= OnTurnOver_EnemyAttack;
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

    private void OnTurnOver_EnemyAttack(object sender, bool isPlayerTurn)
    {
        if (isPlayerTurn)
        {
            return;
        }
        enemyAnim.SetTrigger("attack");
    }

    public void AttackPlayer()
    {
        EffectSoundManager.Instance.PlaySoundEffect(enemyAttackSound);
        Instantiate(stonePrefab, spawnPoint.position, Quaternion.identity);
    }
}
