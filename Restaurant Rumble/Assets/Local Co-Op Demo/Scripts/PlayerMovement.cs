using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 moveInput;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 move = (transform.right * moveInput.x + transform.forward * moveInput.y) * moveSpeed * Time.deltaTime;
        transform.Translate(move);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
