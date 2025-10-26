using UnityEngine;

public class ActionBusyUI : MonoBehaviour
{
    [SerializeField] private GameObject actionButtonParent;
    [SerializeField] private GameObject actionPoints;
    [SerializeField] private GameObject endTurnButton;

    private Player player;
    private void Start()
    {
        player = PlayerActionManager.Instance.GetPlayer();

        PlayerActionManager.Instance.OnBusyChanged += PlayerActionManager_OnBusyChanged;
        TurnSystem.Instance.OnTurnOver += TurnSystem_OnTurnOver;
    }

    private void Show()
    {
        actionButtonParent.SetActive(true);
        actionPoints.SetActive(true);
        endTurnButton.SetActive(true);
    }

    private void Hide()
    {
        actionButtonParent.SetActive(false);
        actionPoints.SetActive(false);
        endTurnButton.SetActive(false);
    }

    private void PlayerActionManager_OnBusyChanged(object sender, bool isBusy)
    {
        if (isBusy)
        {
            Hide();
        }

        else
        {
            if (player.GetActionPoints() != 0)
            {
                Show();
            }
            else
            {
                endTurnButton.SetActive(true);
            }
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
