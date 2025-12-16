using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnZ = 20f;
    public float spawnInterval = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 1f, spawnInterval);
    }

    void SpawnObstacle()
    {
        int lane = Random.Range(0, 3);
        float xPos = (lane - 1) * 2.5f;
        Vector3 spawnPos = new Vector3(xPos, 0.5f, spawnZ);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        spawnZ += 10f;
    }
}
