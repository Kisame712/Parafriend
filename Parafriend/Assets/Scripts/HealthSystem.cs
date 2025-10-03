using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private bool isFriend;
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isFriend)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.Log("Enemy is dead");
        }
    }

}
