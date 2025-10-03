using UnityEngine;

public class Enemy : MonoBehaviour
{
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
