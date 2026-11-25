using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;

    [Header("Batas Area Horizontal")]
    public float minX = -8f;
    public float maxX = 8f;

    [Header("Referensi Komponen")]
    public Animator animator;

    private Rigidbody2D rb;
    private float moveInput;
    private float baseScaleX;
    private bool isWalking;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseScaleX = Mathf.Abs(transform.localScale.x);

        if (animator == null)
            animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        FlipFacing();

        if (animator != null)
        {
            animator.SetBool("isWalking", isWalking);
        }
    }

    void FixedUpdate()
    {
        float nextX = rb.position.x + moveInput * speed * Time.fixedDeltaTime;
        float clampedX = Mathf.Clamp(nextX, minX, maxX);

        isWalking = Mathf.Abs(clampedX - rb.position.x) > 0.0001f;

        rb.MovePosition(new Vector2(clampedX, rb.position.y));
    }

    private void FlipFacing()
    {
        if (moveInput > 0.01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = baseScaleX;
            transform.localScale = scale;
        }
        else if (moveInput < -0.01f)
        {
            Vector3 scale = transform.localScale;
            scale.x = -baseScaleX;
            transform.localScale = scale;
        }
    }
}