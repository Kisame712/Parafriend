using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damageAmount;
    private Player player;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        transform.position += moveSpeed * moveDirection * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            healthSystem.TakeDamage(damageAmount);
            TurnSystem.Instance.TurnChanged();
            Destroy(gameObject);
        }
    }
}
