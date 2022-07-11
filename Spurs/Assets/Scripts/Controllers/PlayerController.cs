using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    public PlayerInput playerInput;

    private float moveSpeed = 10f;
    private Vector3 velocity;
    private Rigidbody rb;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        velocity = new Vector3(MoveInput.x, 0, MoveInput.y).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
