using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int scorePerCoin = 100;
    private ScoreManager scoreManager;

    // このオブジェクトをInstantiateするときに、呼ぶ。その先になければ、その先でも同じことをする。Dependecy Injectionという。
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scorePerCoin);
    }
}
