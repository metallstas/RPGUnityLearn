using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private float xInput;
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float jumpForce = 8f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        HandleInput();
        HandleMovemant();
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetBool("isMoving", isMoving);
    }

    private void HandleInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

    }

    private void HandleMovemant()
    {
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }


}
