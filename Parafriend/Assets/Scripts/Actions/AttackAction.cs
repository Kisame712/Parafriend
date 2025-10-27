using System;
using UnityEngine;

public class AttackAction : BaseAction
{

    [SerializeField] private int attackDamage;
    [SerializeField] private AudioClip playerAttackSound;
    private enum State
    {
        Charge,
        Punch,
        Cooldown
    }
    private State state;
    private float stateTimer;
    private bool canAttack;

    // Event for the animator
    public event EventHandler OnAttackStarted;

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
                float punchStateTimer = 0.4f;
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
        if (FindFirstObjectByType<Enemy>()!=null)
        {
            Enemy enemy = FindFirstObjectByType<Enemy>();
            HealthSystem enemyHealthSystem = enemy.GetHealthSystem();
            EffectSoundManager.Instance.PlaySoundEffect(playerAttackSound);
            enemyHealthSystem.TakeDamage(attackDamage);
        }
    }

    public override void TakeAction(Action onCompleteAction)
    {
        state = State.Charge;
        float chargeStateTimer = 1f;
        stateTimer = chargeStateTimer;

        canAttack = true;
        OnAttackStarted?.Invoke(this, EventArgs.Empty);
        ActionStart(onCompleteAction);
    }
}
