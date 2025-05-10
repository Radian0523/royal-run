using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeToIncrease = 5f;
    GameManager gameManager;

    const string PLAYER_STRING = "Player";

    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            gameManager.IncreaseTime(timeToIncrease);
        }
    }
}
