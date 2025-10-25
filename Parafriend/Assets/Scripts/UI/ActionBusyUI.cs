using UnityEngine;
using System;
public class ActionBusyUI : MonoBehaviour
{
    [SerializeField] private GameObject actionButtonParent;
    private void Start()
    {
        PlayerActionManager.Instance.OnBusyChanged += PlayerActionManager_OnBusyChanged;
        TurnSystem.Instance.OnTurnOver += TurnSystem_OnTurnOver;
    }

    private void Show()
    {
        actionButtonParent.SetActive(true);
    }

    private void Hide()
    {
        actionButtonParent.SetActive(false);
    }

    private void PlayerActionManager_OnBusyChanged(object sender, bool isBusy)
    {
        if (isBusy)
        {
            Hide();
        }

        else
        {
            Show();
        }
    }

    private void TurnSystem_OnTurnOver(object sender, bool isPlayerTurn)
    {
        if (!isPlayerTurn)
        {
            Hide();
        }

        else
        {
            Show();
        }

    }

}
