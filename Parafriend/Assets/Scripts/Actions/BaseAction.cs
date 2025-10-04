using UnityEngine;
using System;
public abstract class BaseAction : MonoBehaviour
{
    protected bool isActive;
    protected Action onCompleteAction;
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

    protected void ActionStart(Action onCompleteAction)
    {
        isActive = true;
        this.onCompleteAction = onCompleteAction;
        OnAnyActionStarted?.Invoke(this, EventArgs.Empty);
    }

    protected void ActionComplete()
    {
        isActive = false;
        Debug.Log("Base Action complete - " + onCompleteAction.ToString());
        onCompleteAction();
        OnAnyActionCompleted?.Invoke(this, EventArgs.Empty);
    }

    public abstract void TakeAction(Action action);
}
