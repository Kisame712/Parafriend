using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ActionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text actionNameText;
    private BaseAction baseAction;
    private Button actionButton;

    private void Awake()
    {
        actionButton = GetComponent<Button>();
    }
    private void Start()
    {
        actionButton.onClick.AddListener(() =>
        {
            if (baseAction != null)
            {
                PlayerActionManager.Instance.SetSelectedAction(baseAction);
            }
        });
    }

    public void SetActionName(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        actionNameText.text = baseAction.GetActionName().ToUpper();
    }
}
