using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 5.0f;


    private Rigidbody2D body2D;
    private SpriteRenderer sprite;
    private Animator animator;

    private float moveInput;

    void Start()
    {
        body2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
        {
            if (moveInput > 0)
            {
                sprite.flipX = false;
            }
            else if (moveInput < 0)
            {
                sprite.flipX = true;
            }

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }

    void FixedUpdate()
    {
        body2D.velocity = new Vector2(moveInput, body2D.velocity.y) * moveSpeed;
    }
}