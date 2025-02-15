using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // Assign your enemy prefab in the Inspector
    [SerializeField] private int minEnemies = 3;
    [SerializeField] private int maxEnemies = 10;
    [SerializeField] private Vector3 spawnArea = new Vector3(10f, 1f, 10f); // Defines the area where enemies spawn

    private void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        int enemyCount = Random.Range(minEnemies, maxEnemies + 1);

        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
                spawnArea.y,
                Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
            );

            GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            // Find the actual enemy model inside the prefab
            Transform enemyModel = newEnemy.transform.GetChild(0); // Assumes the first child is the actual model

            // Set random scale (size)
            float randomSize = Random.Range(0.5f, 2f);
            enemyModel.transform.localScale = Vector3.one * randomSize;

            // Set random base color
            Renderer renderer = enemyModel.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }
}
