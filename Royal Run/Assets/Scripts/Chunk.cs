using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] int coinNumMax = 5;
    [SerializeField] int coinNumMin = 1;
    [SerializeField] float coinDistance = 2f;
    List<int> availableLanes = new List<int> { 0, 1, 2 };

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);
        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) { break; }
            int selectedLane = SelectLane();
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, this.transform);
        }
    }


    void SpawnApple()
    {
        if (availableLanes.Count <= 0) { return; }
        if (Random.value > appleSpawnChance) { return; }
        int selectedLane = SelectLane();
        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPos, Quaternion.identity, this.transform);
    }

    void SpawnCoins()
    {
        if (availableLanes.Count <= 0) { return; }
        if (Random.value > coinSpawnChance) { return; }
        int coinsToSpawn = Random.Range(coinNumMin, coinNumMax + 1);
        int selectedLane = SelectLane();
        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPosZ = transform.position.z + ((i % 2 == 1) ? 1 : -1) * coinDistance * i;
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, spawnPosZ);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity, this.transform);
        }
    }
    private int SelectLane()
    {
        int rndNumIdx = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[rndNumIdx];
        availableLanes.RemoveAt(rndNumIdx);
        return selectedLane;
    }
}
