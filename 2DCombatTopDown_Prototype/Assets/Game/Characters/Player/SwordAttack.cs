using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] Collider2D swordCollider;
    [SerializeField] int swordDamage = 3;
    [SerializeField] float knockbackForce = 700f;

    [SerializeField] Vector3 faceRight = new Vector3(0.6f, 0, 0);
    [SerializeField] Vector3 faceLeft = new Vector3(-0.6f, 0, 0);

    private void Start()
    {
       if(swordCollider == null)
        {
            Debug.Log("Sword collider not set");
        }
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        IDamageable damageableObject = enemyCollider.GetComponent<IDamageable>();

        if(damageableObject != null)
        {
            //Calculate direction between character and slime
            Vector3 parentPosition = transform.parent.position;
            
            //Offset for collision detection changes the direction where the force comes from (close to the player)
            Vector2 direction = (enemyCollider.transform.position - parentPosition).normalized;
            
            //Knockbak is in direction of swordCollider towards collider
            Vector2 knockback = direction * knockbackForce;

            //after making sure the collider has a script that implements IDamageable, we can run the OnHit implementation and pas our Vector2 force
            damageableObject.OnHit(swordDamage, knockback);
        }
        //else
        //{
        //    Debug.LogWarning("Collider does not implement IDamageable");
        //}
    }

    private void IsFacingRight(bool isFacingRight)
    {
        if(isFacingRight)
        {
            gameObject.transform.localPosition = faceRight;
        }
        else
        {
            gameObject.transform.localPosition = faceLeft;
        }
    }
}
