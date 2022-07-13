using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }

    public PlayerInput playerInput;

    [SerializeField] private Transform firePoint;
    [SerializeField] private Bullet bullet;

    private float moveSpeed = 10f;
    private Vector3 velocity;
    private Rigidbody rb;

    private float shootAngle = 30f;
    
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        velocity = new Vector3(MoveInput.x, 0, MoveInput.y).normalized * moveSpeed;

        if (playerInput.actions["FireLeft"].ReadValue<float>() > 0) {
            Shoot(-1 * shootAngle);
        }

        if (playerInput.actions["FireMiddle"].ReadValue<float>() > 0) {
            Shoot(0);
        }

        if (playerInput.actions["FireRight"].ReadValue<float>() > 0) {
            Shoot(shootAngle);
        }
    }

    private void Shoot(float angle)
    {
        Instantiate(bullet, firePoint.position, Quaternion.Euler(0, angle, 0));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
