using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageableCharacter : MonoBehaviour, IDamageable
{
    //properties
    public float Health
    {
        set
        {
            if (value < health)
            {
                animator.SetTrigger("takeDamage");

                //instantiates the healthtext go with script
                RectTransform textTransform = Instantiate(healthText).GetComponent<RectTransform>();

                //display dmg values based on different object's dmg
                textTransform.gameObject.GetComponent<HealthText>().textToDisplay = (health - value).ToString();

                //transform worlds space to screen space for the text
                textTransform.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                //find the canvas for health text
                Canvas canvas = GameObject.FindObjectOfType<Canvas>();

                //sets canvas as parent for the healthText GO
                textTransform.SetParent(canvas.transform);

            }

            health = value;



            if (health <= 0)
            {
                animator.SetBool("isAlive", false);
                Targetable = false;
            }
        }

        get { return health; }
    }

    public bool Targetable
    {
        get { return targetable; }
        set
        {
            targetable = value;
            collider2d.enabled = value;

            if (disableSimulation)//toggle
            {
                rb2d.simulated = false;//turns off physics when object dies.
            }
        }
    }

    public bool Invincible
    {
        get { return invincible; }
        set
        {
            invincible = value;
            if (invincible == true)
            {
                invincibleTimeElapsed = 0f;
            }
        }
    }

    Animator animator;
    Rigidbody2D rb2d;
    Collider2D collider2d;
    [SerializeField] GameObject healthText;
    SpriteRenderer spriteRenderer;

    private bool targetable = true;
    private float health = 3;
    public bool disableSimulation = false;

    private float invincibleTimeElapsed = 0f;
    private bool invincible = false;
    public bool turnInvincible = false;
    public float invicibilityTime = 0.25f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isAlive", true);
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    public void OnHit(float damage, Vector2 knockback)
    {
        if(!Invincible)
        {
            Health -= damage;

            //apply force to the slime
            rb2d.AddForce(knockback); //ForceMode2D.Impulse

            if(turnInvincible)
            {
                //change color while in invincibility
                spriteRenderer.color = Color.red;

                //activate invincibility and timer
                Debug.Log("Invincible ON");
                Invincible = true;
            }
        }
    }
    public void OnHit(float damage)
    {
        if (!Invincible)
        {
            Health -= damage;

            if (turnInvincible)
            {
                //change color while in invincibility
                spriteRenderer.color = Color.red;

                //activate invincibility and timer
                Debug.Log("Invincible ON");
                Invincible = true;
            }
        }
    }

    public void OnObjectDestroyed()//linked to death animation.
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (Invincible)
        {
            invincibleTimeElapsed += Time.deltaTime;

            if(invincibleTimeElapsed > invicibilityTime)
            {
                //color back to default
                spriteRenderer.color = Color.white;

                //restart invincibility and timer
                Debug.Log("Invincible OFF");
                Invincible= false;
            }
        }
    }
}
