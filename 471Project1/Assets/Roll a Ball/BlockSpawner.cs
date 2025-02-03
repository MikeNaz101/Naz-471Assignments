using System.Collections;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject prefab; // Assign in the Inspector
    public int minSpawn = 50; 
    public int maxSpawn = 100;
    public float spawnDuration = 120f; // 2 minutes
    public Vector3 spawnAreaSize = new Vector3(10f, 5f, 10f); // Define area in Inspector

    private int totalToSpawn;
    private float spawnInterval;

    void Start()
    {
        totalToSpawn = Random.Range(minSpawn, maxSpawn + 1); // Randomly picks the amount of blocks to spawn.
        spawnInterval = spawnDuration / totalToSpawn; // Makes the spawning equallyy spread over a set period of time.
        StartCoroutine(SpawnObjects()); // 
    }

    IEnumerator SpawnObjects()
    {
        for (int i = 0; i < totalToSpawn; i++)
        {
            SpawnRandomPrefab();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomPrefab()
    {
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        GameObject obj = Instantiate(prefab, randomPosition, Quaternion.identity);

        // Randomize Size
        float randomScale = Random.Range(0.5f, 20f);
        obj.transform.localScale = Vector3.one * randomScale;

        // Randomize Mass
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.mass = Random.Range(0.5f, 10f);

        // Randomize Color
        Renderer renderer = obj.GetComponent<Renderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
        
    }
}