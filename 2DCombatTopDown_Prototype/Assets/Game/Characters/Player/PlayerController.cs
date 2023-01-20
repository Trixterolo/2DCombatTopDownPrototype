using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //property
    private bool IsMoving
    {
        set
        {
            isMoving = value;
            animator.SetBool("isMoving", isMoving);
        }
    }

    [SerializeField] float moveSpeed = 50f;
   // [SerializeField] float maxSpeed = 15f;
    [SerializeField] private float idleFriction;
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
                            //rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity + (movementInput * moveSpeed * Time.fixedDeltaTime), maxSpeed);
            rb2d.AddForce(movementInput * moveSpeed * Time.fixedDeltaTime);

                            //if(rb2d.velocity.magnitude > maxSpeed) //limits player speed?
                            //{
                            //    float limitedSpeed = Mathf.Lerp(rb2d.velocity.magnitude, maxSpeed, idleFriction);
                            //    rb2d.velocity = rb2d.velocity.normalized * limitedSpeed;
                            //}
            

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
            rb2d.velocity = Vector2.Lerp(rb2d.velocity, Vector2.zero, idleFriction);
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
