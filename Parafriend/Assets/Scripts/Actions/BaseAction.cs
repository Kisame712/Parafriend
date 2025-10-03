using UnityEngine;
using System;
public abstract class BaseAction : MonoBehaviour
{
    protected bool isActive;
    protected Action onActionCompleted;
    protected Player player;

    public static event EventHandler OnAnyActionStarted;
    public static event EventHandler OnAnyActionCompleted;

    protected virtual void Awake()
    {
        player = GetComponent<Player>();
    }
    public abstract string GetActionName();

    public virtual int GetActionPointsRequired()
    {
        return 1;
    }

    protected void ActionStart(Action onActionCompleted)
    {
        isActive = true;
        this.onActionCompleted = onActionCompleted;
        OnAnyActionStarted?.Invoke(this, EventArgs.Empty);
    }

    protected void ActionComplete()
    {
        isActive = false;
        onActionCompleted();
        OnAnyActionCompleted?.Invoke(this, EventArgs.Empty);
    }

    public abstract void TakeAction(Action action);
}
