using UnityEngine;
using TMPro;
using System;
public class ActionButtonParent : MonoBehaviour
{
    [SerializeField] private Transform actionButtonPrefab;
    [SerializeField] private TMP_Text actionPointsDisplayText;

    private Player player;
    private BaseAction[] baseActions;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        baseActions = player.GetBaseActions();
        PlayerActionManager.Instance.OnActionStarted += PlayerActionManager_OnActionStarted;
        TurnSystem.Instance.OnTurnOver += TurnSystem_OnTurnOver;
        CreateActionButtons();
        UpdateActionPoints();
    }

    private void CreateActionButtons()
    {
        foreach(BaseAction baseAction in baseActions)
        {
            Transform actionButtonPrefabTransform = Instantiate(actionButtonPrefab, transform);
            ActionButton actionButtonComponent = actionButtonPrefabTransform.GetComponent<ActionButton>();

            actionButtonComponent.SetActionName(baseAction);

        }
    }

    private void PlayerActionManager_OnActionStarted(object sender, int actionPointsToReduce)
    {
        player.ReduceActionPoints(actionPointsToReduce);
        UpdateActionPoints();
    }

    private void TurnSystem_OnTurnOver(object sender, bool isPlayerTurn)
    {
        if (isPlayerTurn)
        {
            return;
        }
        UpdateActionPoints();
    }

    private void UpdateActionPoints()
    {
        actionPointsDisplayText.text = $"Action Points : {player.GetActionPoints().ToString()}";
    }

}
