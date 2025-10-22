using UnityEngine;

public class PoisonSystem : MonoBehaviour
{
    [SerializeField] private int maxPoisonTolerance;
    private int poisonLevel = 0;


    public void ResetPoisonLevel()
    {
        poisonLevel = 0;
        Debug.Log("Sucked poison");
    }

    public void PoisonAttack(int poisonAmount)
    {
        poisonLevel += poisonAmount;
        if(poisonLevel > maxPoisonTolerance)
        {
            poisonLevel = maxPoisonTolerance;
        }
    }
}
