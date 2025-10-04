using UnityEngine;
using System;
public class PlayerActionManager : MonoBehaviour
{
    public static PlayerActionManager Instance { private set; get; }

    // Event to call the UI script to update the action points
    public event EventHandler OnActionStarted;
    public event EventHandler<bool> OnBusyChanged;
    private BaseAction selectedAction;

    private Player player;

    private bool isBusy;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one Instance of PlayerActionManager" + Instance.transform);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        if (isBusy)
        {
            return;
        }
        HandleSelectedAction();
    }

    private void SetBusy()
    {
        isBusy = true;
        OnBusyChanged?.Invoke(this, isBusy);
    }

    private void ClearBusy()
    {
        isBusy = false;
        OnBusyChanged?.Invoke(this, isBusy);
    }

    public void SetSelectedAction(BaseAction baseAction)
    {
        selectedAction = baseAction;
    }

    public BaseAction GetSelectedAction()
    {
        return selectedAction;
    }

    private void HandleSelectedAction()
    {
        if (selectedAction == null)
        {
            return;
        }
        SetBusy();
        Debug.Log("Action Set");
        selectedAction.TakeAction(ClearBusy);
        Debug.Log("Take Action called");
        OnActionStarted?.Invoke(this, EventArgs.Empty);
        selectedAction = null;
    }
}
