using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] Collider2D swordCollider;
    [SerializeField] int swordDamage = 3;
    [SerializeField] float knockbackForce = 100f;

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
            Vector3 parentPosition = gameObject.GetComponentInParent<Transform>().position;
            Vector2 direction = (Vector2) (enemyCollider.gameObject.transform.position - parentPosition).normalized;
            Vector2 knockback = direction * knockbackForce;

            //enemyCollider.SendMessage("OnHit", swordDamage, knockback);
            damageableObject.OnHit(swordDamage, knockback);
        }
        else
        {
            Debug.LogWarning("Collider does not implement IDamageable");
        }
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
