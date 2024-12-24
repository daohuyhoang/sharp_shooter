using UnityEngine;

public class EnemyHealthy : MonoBehaviour
{
    [SerializeField] int startingHealth = 3;
    [SerializeField] GameObject robotExplosionSFX;
    
    GameManager gameManager;
    
    int currentHealth;
    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        gameManager.AdjustEnemiesLeft(1);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            gameManager.AdjustEnemiesLeft(-1);
            SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Instantiate(robotExplosionSFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
