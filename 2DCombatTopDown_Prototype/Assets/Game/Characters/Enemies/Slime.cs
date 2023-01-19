using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IDamageable
{
    public float Health
    {
        set
        {
            if (value < health)
            {
                animator.SetTrigger("takeDamage");
            }

            health = value;



            if(health <= 0)
            {
                animator.SetBool("isAlive", false);
                //Destroy(gameObject);
            }
        }
        
        get { return health; }
    }

    Animator animator;
    Rigidbody2D rb2d;

    private bool isAlive = true;
    public float health = 3;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;

        //apply force to the slime
        rb2d.AddForce(knockback);
        Debug.Log("Force" + knockback);
    }
    public void OnHit(float damage)
    {
        //Debug.Log("Slime hit " + damage);
        Health -= damage;
    }
}
