using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MouseButNot : MonoBehaviour
{
    float fakeClick;
    Vector2 fakeMoveInput;
    [SerializeField] float mouseMovementSpeed;

    void Update()
    {
        transform.position += (new Vector3(fakeMoveInput.x, fakeMoveInput.y,0) * mouseMovementSpeed * Time.deltaTime); 
    }
    void OnFakeMove(InputValue value)
    {
        fakeMoveInput = value.Get<Vector2>();
    }

    void OnFakeClick(InputValue value)
    {
        fakeClick = value.Get<float>();
    }
}
