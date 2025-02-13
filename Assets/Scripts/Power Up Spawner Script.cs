using UnityEngine;
using System.Collections;

public class PowerUpSpawnerScript : MonoBehaviour
{
    public GameObject speedPowerUpPrefab;
    public GameObject ballSizePowerUpPrefab;
    
    public float spawnInterval = 5f;
    public float xMin = -7, xMax = 7, zMin = -7, zMax = 7;
    public float spawnTimer = 5f;
    void Start()
    {
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            GameObject powerUp = (Random.value > 0.5f) ? speedPowerUpPrefab : ballSizePowerUpPrefab;
            yield return new WaitForSeconds(spawnTimer);
            Vector3 spawnPosition = new Vector3(Random.Range(xMin, xMax), transform.position.y, Random.Range(zMin, zMax));
            Instantiate(powerUp, spawnPosition, Quaternion.identity);
        }
    }
}
