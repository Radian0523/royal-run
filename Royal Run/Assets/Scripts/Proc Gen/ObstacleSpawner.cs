using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstaclePrefabs;
    [SerializeField] float obstacleSpawnTime = 1f;
    [SerializeField] float minObstacleSpawnTime = 0.02f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth = 4f;

    void Start()
    {

        StartCoroutine(SpawnObstacleRoutine());


    }

    public void DecreaseObstacleSpawnTimeInterval(float amount)
    {
        obstacleSpawnTime += amount;
        obstacleSpawnTime = Mathf.Max(obstacleSpawnTime, minObstacleSpawnTime);
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            yield return new WaitForSeconds(obstacleSpawnTime);
            Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            Instantiate(obstaclePrefab, spawnPos, Random.rotation, obstacleParent);
        }

    }

}
