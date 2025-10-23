using UnityEngine;
using System;

public class PoisonSystem : MonoBehaviour
{
    [SerializeField] private int maxPoisonTolerance;
    [SerializeField] private int maxPoisonPerTurn;
    private int poisonLevel = 0;

    public event EventHandler OnPoisonIncreased;
    public event EventHandler OnPoisonSucked;

    public void ResetPoisonLevel()
    {
        poisonLevel = 0;
        OnPoisonSucked?.Invoke(this, EventArgs.Empty);
    }

    private void PoisonAttack(int poisonAmount)
    {
        poisonLevel += poisonAmount;
        if(poisonLevel > maxPoisonTolerance)
        {
            poisonLevel = maxPoisonTolerance;
        }
        OnPoisonIncreased?.Invoke(this, EventArgs.Empty);
    }

    private void OnTurnOver_ApplyRandomPoison(object sender, EventArgs e)
    {
        int randomPoisonAttack = UnityEngine.Random.Range(0, maxPoisonPerTurn);
        PoisonAttack(randomPoisonAttack);
    }

    public float GetPoisonNormalized()
    {
        return (float)poisonLevel / maxPoisonTolerance;
    }
}
