using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeToIncrease = 5f;
    [SerializeField] float intervalToDecrease = 0.02f;
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;

    const string PLAYER_STRING = "Player";

    public void Init(GameManager gameManager, ObstacleSpawner obstacleSpawner)
    {
        this.gameManager = gameManager;
        this.obstacleSpawner = obstacleSpawner;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            gameManager.IncreaseTime(timeToIncrease);
            obstacleSpawner.DecreaseObstacleSpawnTimeInterval(-intervalToDecrease);
        }
    }
}
