using System;
using UnityEngine;

public class HealAction : BaseAction
{
    [SerializeField] private int healAmount;

    public event EventHandler OnHealStarted;
    public override string GetActionName()
    {
        return "HEAL";
    }

    public override int GetActionPointsRequired()
    {
        return 1;
    }

    public override void TakeAction(Action onCompleteAction)
    {
        ActionStart(onCompleteAction);
        Heal();
        OnHealStarted?.Invoke(this, EventArgs.Empty);
    }

    private void Heal()
    {
        // Add health taking sound effects and some UI display of health increase
        HealthSystem playerHealth = player.GetHealthSystem();
        playerHealth.Healing(healAmount);
        ActionComplete();
    }

}
