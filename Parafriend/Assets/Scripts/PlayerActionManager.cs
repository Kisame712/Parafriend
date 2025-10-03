using UnityEngine;

public class PlayerActionManager : MonoBehaviour
{
    public static PlayerActionManager Instance { private set; get; }

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
    }

    private void SetBusy()
    {
        isBusy = true;
    }

    private void ClearBusy()
    {
        isBusy = false;
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


    }
}
