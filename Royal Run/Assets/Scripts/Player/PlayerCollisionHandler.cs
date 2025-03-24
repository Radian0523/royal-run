using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    const string HIT_STRING = "Hit";
    [SerializeField] float collisionCoolDown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;

    float coolDownTimer;

    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update()
    {

        coolDownTimer += Time.deltaTime;


    }

    void OnCollisionEnter(Collision other)
    {
        if (coolDownTimer < collisionCoolDown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(HIT_STRING);
        coolDownTimer = 0f;
        // Debug.Log(other.gameObject.name);
    }
}
