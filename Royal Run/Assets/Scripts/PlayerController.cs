using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float zClampRange = 5f;
    Rigidbody rb;
    Vector2 movement;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 currentPos = rb.position;
        Vector3 moveDir = new Vector3(movement.x, 0f, movement.y);
        // FixedUpdate の中でTime.deltaTimeを呼べば、Unityが自動的にTime.fixedDeltaTimeに変換してくれる。
        // Vector3の複数要素に同じものをかけるなら、一旦全体にかければよい。（ただし、2個なら、もう一個が０である必要はある）
        Vector3 newPos = currentPos + moveDir * (moveSpeed * Time.fixedDeltaTime);
        float clampedXPos = Mathf.Clamp(newPos.x, -xClampRange, xClampRange);
        float clampedZPos = Mathf.Clamp(newPos.z, -zClampRange, zClampRange);
        Vector3 clampedPos = new Vector3(clampedXPos, 0f, clampedZPos);
        rb.MovePosition(clampedPos);
    }

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }


}
