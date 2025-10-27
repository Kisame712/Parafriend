using UnityEngine;
using System;

public class TurnSystem : MonoBehaviour
{
    public static TurnSystem Instance { private set; get; }
    public event EventHandler<bool> OnTurnOver;

    private bool isPlayerTurn;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There exists more than one instance of TurnSystem");
            Destroy(gameObject);
            return;
        }
        Instance = this;
        isPlayerTurn = true;
        OnTurnOver?.Invoke(this, isPlayerTurn);
    }

    public void TurnChanged()
    {
        isPlayerTurn = !isPlayerTurn;
        OnTurnOver?.Invoke(this, isPlayerTurn);
    }
}
