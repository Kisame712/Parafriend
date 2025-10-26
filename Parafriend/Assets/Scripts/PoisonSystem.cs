using UnityEngine;
using System;

public class PoisonSystem : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private int maxPoisonTolerance;
    [SerializeField] private int maxPoisonPerTurn;
    [SerializeField] private int damageFromPoison;
    private int poisonLevel = 0;

    public event EventHandler OnPoisonIncreased;
    public event EventHandler OnPoisonSucked;
    public event EventHandler OnPoisonMaxed;

    private void Start()
    {
        TurnSystem.Instance.OnTurnOver += OnTurnOver_ApplyRandomPoison;
    }

    public void ResetPoisonLevel()
    {
        poisonLevel = 0;
        OnPoisonSucked?.Invoke(this, EventArgs.Empty);
    }

    private void PoisonAttack(int poisonAmount)
    {
        poisonLevel += poisonAmount;
        if(poisonLevel >= maxPoisonTolerance)
        {
            poisonLevel = maxPoisonTolerance;
            HealthSystem healthSystem = player.GetHealthSystem();
            healthSystem.TakeDamage(damageFromPoison);
            OnPoisonMaxed?.Invoke(this, EventArgs.Empty);
        }
        OnPoisonIncreased?.Invoke(this, EventArgs.Empty);
    }

    private void OnTurnOver_ApplyRandomPoison(object sender, bool isPlayerTurn)
    {
        if (isPlayerTurn)
        {
            return;
        }
        //int randomPoisonAttack = UnityEngine.Random.Range(0, maxPoisonPerTurn);
        int randomPoisonAttack = 10;
        PoisonAttack(randomPoisonAttack);
    }

    public float GetPoisonNormalized()
    {
        return (float)poisonLevel / maxPoisonTolerance;
    }
}
