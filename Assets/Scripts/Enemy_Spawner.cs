using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn 
    public GameObject enemyPrefab2; // The second enemy prefab to spawn

    public GameObject enemyPrefab3; // The third enemy prefab to spawn

    public GameObject enemyPrefab4; // The third enemy prefab to spawn


    public GameObject preSpawnIndicatorPrefab; // The pre-spawn indicator prefab

    public GameObject minibossPrefab;
    public GameObject bossPrefab;

    public float spawnInterval; // Time between spawns
    public float preSpawnDelay = 0.5f; // Time before the enemy actually spawns

    private float timeSinceLastSpawn;
    private Camera mainCamera;

    void Start()
    {

        mainCamera = Camera.main;
    }



    public void enemySpawn()
    {
        Debug.Log("Enemy Spawned");
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            StartCoroutine(SpawnEnemyWithIndicator());
            timeSinceLastSpawn = 0f;
        }
    }

    public void minibossSpawn(){
        // spawn miniboss here
        Instantiate(minibossPrefab, new Vector2(0, 0), Quaternion.identity);
    }

    public void minibossEnemiesSpawn(){
        // spawn miniboss enemies here
        for (int i = 0; i < 5; i++)
        {

            
            float spawnX = Random.Range(10,10);
            float spawnY = Random.Range(10, 10);
            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Instantiate(enemyPrefab4, spawnPosition, Quaternion.identity);
        }
    }

    public void bossSpawn(){
        // spawn boss here
        Instantiate(bossPrefab, new Vector2(0, 0), Quaternion.identity);
    }

    public System.Collections.IEnumerator SpawnEnemyWithIndicator()
    {
        // Calculate the spawn area based on the camera's view
        Vector2 spawnAreaMin, spawnAreaMax;
        CalculateSpawnArea(out spawnAreaMin, out spawnAreaMax);

        // Randomly determine the spawn position within the defined area
        float spawnX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Instantiate the pre-spawn indicator at the spawn position
        GameObject indicator = Instantiate(preSpawnIndicatorPrefab, spawnPosition, Quaternion.identity);

        // Wait for the pre-spawn delay
        yield return new WaitForSeconds(preSpawnDelay);

        // Destroy the indicator
        Destroy(indicator);

        // Randomly determine which enemy prefab to spawn
        int randomEnemy = Random.Range(0, 2);

        // Instantiate the selected enemy prefab at the spawn position
        if (randomEnemy == 0)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        else if (randomEnemy == 1)
        {
            Instantiate(enemyPrefab2, spawnPosition, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefab3, spawnPosition, Quaternion.identity);
        }
    }

    void CalculateSpawnArea(out Vector2 min, out Vector2 max)
    {
        float cameraHeight = mainCamera.orthographicSize * 2;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        Vector3 cameraPosition = mainCamera.transform.position;

        min = new Vector2(cameraPosition.x - cameraWidth / 2, cameraPosition.y - cameraHeight / 2);
        max = new Vector2(cameraPosition.x + cameraWidth / 2, cameraPosition.y + cameraHeight / 2);
    }
}