using UnityEngine;

public class Apple : Pickup
{
    LevelGenerator levelGenerator;
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    protected override void OnPickup()
    {
        Debug.Log("Power Up!");
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
    }
}
