using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public GameObject[] balloons;       // 10 balloon prefabs
    public float spawnInterval = 1.5f;  // seconds
    public float xRange = 2.5f;         // horizontal spawn range
    public float ySpawn = -6f;          // bottom y position

    void Start()
    {
        InvokeRepeating(nameof(SpawnBalloon), 1f, spawnInterval);
    }

    void SpawnBalloon()
    {
        // Random balloon from array
        int i = Random.Range(0, balloons.Length);

        // Random X position
        float xPos = Random.Range(-xRange, xRange);

        // 2D spawn position
        Vector3 spawnPos = new Vector3(xPos, ySpawn, 0f);

        // Instantiate balloon
        Instantiate(balloons[i], spawnPos, Quaternion.identity);

       // Debug.Log("Spawned Balloon: " + balloons[i].name + " at X: " + xPos);
    }
}
