using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int actionPointsPerTurn = 4;
    private int actionPoints;
    private HealthSystem healthSystem;
    private PoisonSystem poisonSystem;
    private BaseAction[] baseActionArray;
    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        baseActionArray = GetComponents<BaseAction>();
        poisonSystem = GetComponent<PoisonSystem>();
        ResetActionPoints();
    }

    public int GetActionPoints()
    {
        return actionPoints;
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }

    public PoisonSystem GetPoisonSystem()
    {
        return poisonSystem;
    }

    public BaseAction[] GetBaseActions()
    {
        return baseActionArray;
    }


    public void ReduceActionPoints(int actionPointsToReduce)
    {
        this.actionPoints -= actionPointsToReduce;
        if(actionPoints <= 0)
        {
            actionPoints = 0;
        }
    }

    private void OnTurnOver_ReplenishActionPoints()
    {
        ResetActionPoints();
    }

    private void ResetActionPoints()
    {
        actionPoints = actionPointsPerTurn;
    }
}
