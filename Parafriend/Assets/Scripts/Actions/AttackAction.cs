using System;
using UnityEngine;

public class AttackAction : BaseAction
{
    [SerializeField] private int attackDamage;
    private enum State
    {
        Charge,
        Punch,
        Cooldown
    }
    private State state;
    private float stateTimer;
    private bool canAttack;
    public override string GetActionName()
    {
        return "ATTACK";
    }

    public override int GetActionPointsRequired()
    {
        return 1;
    }

    private void Update()
    {
        if (!isActive)
        {
            return;
        }

        stateTimer -= Time.deltaTime;

        switch (state)
        {
            case State.Charge:
                // Add camera effects and particle effects later if necessary
                break;
            case State.Punch:
                if (canAttack)
                {
                    Punch();
                    canAttack = false;
                }
                break;
            case State.Cooldown:
                break;
        }

        if(stateTimer <= 0)
        {
            NextState();
        }
    }

    private void NextState()
    {
        switch (state)
        {
            case State.Charge:
                state = State.Punch;
                float punchStateTimer = 0.1f;
                stateTimer = punchStateTimer;
                break;
            case State.Punch:
                state = State.Cooldown;
                float cooldownStateTimer = 0.1f;
                stateTimer = cooldownStateTimer;
                break;
            case State.Cooldown:
                ActionComplete();
                break;
        }

    }

    private void Punch()
    {
        if (TryGetComponent<Enemy>(out Enemy enemy))
        {
            HealthSystem enemyHealthSystem = enemy.GetHealthSystem();
            enemyHealthSystem.TakeDamage(attackDamage);
        }
    }

    public override void TakeAction(Action onCompletedAction)
    {
        canAttack = true;
        ActionStart(onActionCompleted);
    }
}
