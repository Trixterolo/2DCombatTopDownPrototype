using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D rb2d;
    DamageableCharacter damageableCharacter;

    public float damage = 1;
    public float knockbackForce = 300f;
    public float moveSpeed = 15f;

    [SerializeField] DetectionZone detectionZone;

    private void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        damageableCharacter = GetComponent<DamageableCharacter>();
    }

    private void FixedUpdate()
    {
        if (damageableCharacter.Targetable && detectionZone.detectedObjects.Count > 0)
        {
            //calculate direction target object.
            Vector2 direction = (detectionZone.detectedObjects[0].transform.position - transform.position).normalized;
            //move towards detected object.
            rb2d.AddForce(direction * moveSpeed * Time.fixedDeltaTime);

        }
    }

    private void OnCollisionEnter2D(Collision2D objectCollider)
    {
        Collider2D collider2d = objectCollider.collider;
        IDamageable damageable= objectCollider.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Calculate direction between character and slime
            //Vector3 parentPosition = transform.parent.position; (this)enemy doesnt need this.

            //Offset for collision detection changes the direction where the force comes from (close to the player)
            Vector2 direction = (collider2d.transform.position - transform.position).normalized;

            //Knockbak is in direction of enemy towards collider
            Vector2 knockback = direction * knockbackForce;

            //after making sure the collider has a script that implements IDamageable, we can run the OnHit implementation and pas our Vector2 force
            damageable.OnHit(damage, knockback);
        }
    }
}
