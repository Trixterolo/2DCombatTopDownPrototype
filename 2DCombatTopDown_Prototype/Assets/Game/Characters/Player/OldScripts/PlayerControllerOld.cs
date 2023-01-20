//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerControllerOld : MonoBehaviour
//{
//    [Header("Movement")]
//    [SerializeField] float moveSpeed = 5f;
//    [SerializeField] float raycastCollisionOffset = 0.05f;
    
//    [SerializeField] ContactFilter2D movementLayerFilter;
//    [SerializeField] SwordAttack swordAttack;

//    Vector2 movementInput;
//    SpriteRenderer spriteRenderer;
//    Rigidbody2D rb2d;
//    Animator animator;
//    List<RaycastHit2D> raycastCollisionsInfo = new List<RaycastHit2D>();
//    private bool canMove = true;


//    // Start is called before the first frame update
//    void Start()
//    {
//        rb2d = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//        spriteRenderer= GetComponent<SpriteRenderer>();
//    }

    

//    private void FixedUpdate()
//    {
//        if (canMove)
//        {
//            PlayerMoving();
//            MovementDirection();

//        }


//    }

//    private void OnMove(InputValue movementValue)
//    {
//        movementInput = movementValue.Get<Vector2>();
//    }

//    private bool TryMove(Vector2 direction)
//    {
//        if(direction != Vector2.zero)
//        { 
//        //Check for potential collisions. Raycast help us check whether a move is valid BEFORE we make the move.
//        //count = 0 means no collision objects detected.
//        int count = rb2d.Cast
//            (
//                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
//                movementLayerFilter, //The settings that determine where a collison can occur on such layers to collide with
//                raycastCollisionsInfo, //List of collisions to store the found collisions into after the Cast is finished
//                moveSpeed * Time.fixedDeltaTime + raycastCollisionOffset // the amount to cast equal to the movement + offset
//            );
       
//            if (count == 0)
//            {
//                rb2d.MovePosition(rb2d.position + direction * moveSpeed * Time.fixedDeltaTime);
//                return true;
//            }
//            else 
//            { 
//                return false; 
//            }
//        }
//        else
//        {
//            //cant move if there's no DIRECTION to move in.
//            return false;
//        }
//    }

//    private void PlayerMoving()
//    {
//        //if movement is not 0, try to move with both axis.
//        if (movementInput != Vector2.zero)
//        {
//            bool success = TryMove(movementInput);

//            if (!success) //if unable to move, try move on X axis.
//            {
//                success = TryMove(new Vector2(movementInput.x, 0));

//                if (!success)//if still unable to move, try move on Y axis.
//                {
//                    success = TryMove(new Vector2(0, movementInput.y));
//                }// all these checks ALLOW Sliding along collided objects.
//            }
//            animator.SetBool("isMoving", success);
//        }
//        else
//        {
//            animator.SetBool("isMoving", false);
//        }
//    }

//    private void MovementDirection()
//    {
//        //set direction of sprite to movement direction
//        if (movementInput.x < 0)
//        {
//            spriteRenderer.flipX = true;
//        }
//        else if (movementInput.x > 0)
//        {
//            spriteRenderer.flipX = false;
//        }
//    }

//    private void OnFire()
//    {
//        animator.SetTrigger("swordAttack");
//    }

//    public void SwordAttack()
//    {
//        LockMovement();

//        if(spriteRenderer.flipX == true)
//        {
//            swordAttack.AttackLeft();
//        }
//        else
//        {
//            swordAttack.AttackRight();
//        }
//    }

//    public void EndSwordAttack()
//    {
//        UnlockMovement();
//        swordAttack.StopAttack();
//    }

//    public void LockMovement()
//    {
//        canMove = false;
//    }

//    public void UnlockMovement()
//    {
//        canMove = true;
//    }
//}
