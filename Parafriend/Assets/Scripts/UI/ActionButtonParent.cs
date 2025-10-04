using UnityEngine;

public class ActionButtonParent : MonoBehaviour
{
    [SerializeField] private Transform actionButtonPrefab;

    private Player player;
    private BaseAction[] baseActions;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        baseActions = player.GetBaseActions();
        CreateActionButtons();
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

}
