using System;
using System.Collections;
using UnityEngine;

public class SuckAction : BaseAction
{
    [SerializeField] private int suckDamage;
    public event EventHandler OnSuckStarted;
    public override string GetActionName()
    {
        return "SUCK";
    }

    public override void TakeAction(Action onCompleteAction)
    {
        ActionStart(onCompleteAction);
        Suck();
        OnSuckStarted?.Invoke(this, EventArgs.Empty);
    }

    private void Suck()
    {
        StartCoroutine(AddSuckDelay());
    }

    IEnumerator AddSuckDelay()
    {
        yield return new WaitForSeconds(1f);
        PoisonSystem poisonSystem = player.GetPoisonSystem();
        poisonSystem.ResetPoisonLevel();
        HealthSystem healthSystem = player.GetHealthSystem();
        healthSystem.TakeDamage(suckDamage);
        ActionComplete();
    }
}
