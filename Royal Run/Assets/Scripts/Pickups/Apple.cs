using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;
    LevelGenerator levelGenerator;

    // このオブジェクトをInstantiateするときに、呼ぶ。その先になければ、その先でも同じことをする。
    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        Debug.Log("Power Up!");
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
