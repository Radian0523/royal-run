using Unity.Cinemachine;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float shakeModifier = 10f;
    [SerializeField] ParticleSystem collisionPartilceSystem;
    CinemachineImpulseSource cinemachineImpulseSource;
    [SerializeField] AudioSource boulderSmashAudioSource;
    [SerializeField] float sizeModifier = 0.97f;
    [SerializeField] float collisionCooldown = 1f;

    private float startingScale;
    private float collisionTimer;

    void Awake()
    {
        cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        startingScale = transform.localScale.x;
        collisionTimer = collisionCooldown; // 最初鳴らすため
    }

    void Update()
    {
        collisionTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        if (collisionTimer <= collisionCooldown) return;
        FireImpulse();
        CollisionFX(other);
        MinimizeRock();
        collisionTimer = 0;
    }

    private void MinimizeRock()
    {
        transform.localScale *= sizeModifier;
    }

    private void FireImpulse()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        // distanceが大きければ多きいほど、shakeIntensityを小さくしたい⇒とりあえず単純に反比例させてみるか、ぐらいの気持ち
        float shakeIntensity = 1f / distance * shakeModifier * transform.localScale.x / startingScale;
        shakeIntensity = Mathf.Min(shakeIntensity, 1f);
        cinemachineImpulseSource.GenerateImpulse(shakeIntensity);
    }

    void CollisionFX(Collision other)
    {
        // 衝突した場所にParticleSystemを移動させて、
        ContactPoint contactPoint = other.contacts[0];
        collisionPartilceSystem.transform.position = contactPoint.point;
        collisionPartilceSystem.Play();
        boulderSmashAudioSource.volume = transform.localScale.x / startingScale;
        boulderSmashAudioSource.Play();
    }
}
