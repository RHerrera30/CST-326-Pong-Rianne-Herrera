using UnityEngine;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public GameObject speedPowerUpPrefab;

    public float spawnInterval = 5f;
    public float xMin = -7, xMax = 7, zMin = -7, zMax = 7;
    
    private float spawnTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (speedPowerUpPrefab == null)
        {
            Debug.LogError("SpeedPowerUpPrefab is missing! Assign it in the Inspector.");
            return;
        }
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnPowerUp();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnPowerUp()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), transform.position.y, Random.Range(zMin, zMax));
        Instantiate(speedPowerUpPrefab, spawnPosition, Quaternion.identity);
    }
}
