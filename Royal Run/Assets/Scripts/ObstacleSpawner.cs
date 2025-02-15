using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    int obstacleSpawned = 0;
    void Start()
    {
        while (obstacleSpawned < 5)
        {
            StartCoroutine(func());
        }

    }

    IEnumerator func()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        obstacleSpawned++;
    }

}
