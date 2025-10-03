using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int actionPointsPerTurn = 4;

    private HealthSystem healthSystem;
    private BaseAction[] baseActionArray;
    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        baseActionArray = GetComponents<BaseAction>();
    }

    public int GetActionPointsPerTurn()
    {
        return actionPointsPerTurn;
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

    public BaseAction[] GetBaseActions()
    {
        return baseActionArray;
    }

}
