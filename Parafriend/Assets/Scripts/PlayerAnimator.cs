using UnityEngine;
using System;
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Player player;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void Start()
    {
        if(player.TryGetComponent<AttackAction>(out AttackAction attackAction))
        {
            attackAction.OnAttackStarted += AttackAction_OnAttackStarted;
        }

        if(player.TryGetComponent<HealAction>(out HealAction healAction))
        {
            healAction.OnHealStarted += HealAction_OnHealStarted;
        }

    }

    private void AttackAction_OnAttackStarted(object sender, EventArgs e)
    {
        animator.SetTrigger("attack");
    }

    private void HealAction_OnHealStarted(object sender, EventArgs e)
    {
        animator.SetTrigger("heal");
    }

}
