using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int scorePerCoin = 100;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scorePerCoin);
    }
}
