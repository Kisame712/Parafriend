using System;
using UnityEngine;

public class SuckAction : BaseAction
{
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
        PoisonSystem poisonSystem = player.GetPoisonSystem();
        poisonSystem.ResetPoisonLevel();
        ActionComplete();
    }
}
