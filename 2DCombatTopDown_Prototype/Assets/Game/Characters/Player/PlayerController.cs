using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    [SerializeField] float moveSpeed = 150f;
    [SerializeField] float maxSpeed = 8f;
    [SerializeField] GameObject swordHitBox;

    Rigidbody2D rb2d;
    Animator animator;
    SpriteRenderer spriteRenderer;
    Vector2 movementInput = Vector2.zero;
    
    private bool isMoving = false;
    private bool canMove = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        PlayerMoving();
    }

    private void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    private void PlayerMoving()
    {
        if (canMove == true && movementInput != Vector2.zero)
        {
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity + (movementInput * moveSpeed * Time.fixedDeltaTime), maxSpeed);

            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("IsFacingRight", false);
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("IsFacingRight", true);
            }

            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }

    private void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }
}
