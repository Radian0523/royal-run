using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    const string HIT_STRING = "Hit";
    [SerializeField] float collisionCoolDown = 1f;

    float coolDownTimer;

    void Update()
    {

        coolDownTimer += Time.deltaTime;


    }

    void OnCollisionEnter(Collision other)
    {
        if (coolDownTimer < collisionCoolDown) return;
        animator.SetTrigger(HIT_STRING);
        coolDownTimer = 0f;
        // Debug.Log(other.gameObject.name);
    }
}
