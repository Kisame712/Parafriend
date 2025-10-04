using UnityEngine;
using System;
public class ActionBusyUI : MonoBehaviour
{
    [SerializeField] private GameObject actionButtonParent;
    private void Start()
    {
        PlayerActionManager.Instance.OnBusyChanged += PlayerActionManager_OnBusyChanged;
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

}
