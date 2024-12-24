using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;
    [SerializeField] float spwanTime = 5f;
    [SerializeField] Transform spawnPoint;

    PlayerHealth player;
    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (player)
        {
            Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spwanTime);
        }
    }
}
