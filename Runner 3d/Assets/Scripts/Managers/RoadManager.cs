using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject roadSegmentPrefab;  // Prefab du segment de route
    public GameObject obstaclePrefab;     // Prefab obstacle
    public int initialSegments = 5;       // Nombre de segments initiaux
    public float segmentLength = 50f;     // Longueur d'un segment
    public Transform player;              // Ton cube Player

    private float spawnZ = 0f;            // Z du prochain segment
    private float safeZone = 100f;        // Distance avant spawn

    void Start()
    {
        for (int i = 0; i < initialSegments; i++)
        {
            SpawnSegment();
        }
    }

    void Update()
    {
        if (player.position.z + safeZone > spawnZ)
        {
            SpawnSegment();
        }
    }

    void SpawnSegment()
    {
        // Crée le segment de route
        GameObject segment = Instantiate(roadSegmentPrefab, new Vector3(0, 0, spawnZ), Quaternion.identity);

        // Spawn obstacles aléatoires
        int obstaclesPerSegment = Random.Range(1, 4);
        for (int i = 0; i < obstaclesPerSegment; i++)
        {
            int lane = Random.Range(0, 3); // 0=gauche,1=milieu,2=droite
            float xPos = (lane - 1) * 2.5f;
            float zPos = spawnZ + Random.Range(10f, segmentLength - 10f);
            Vector3 spawnPos = new Vector3(xPos, 0.5f, zPos);
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }

        spawnZ += segmentLength;
    }
}
