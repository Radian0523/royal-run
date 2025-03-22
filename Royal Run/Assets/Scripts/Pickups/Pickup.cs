using UnityEngine;

// GameObjectに直接アタッチすることはできない
public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;
    const string PLAYER_STRING = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_STRING))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    protected abstract void OnPickup();

}
