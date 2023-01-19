//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SwordAttackOld : MonoBehaviour
//{
//    Vector2 rightAttackOffset;

//    [SerializeField] Collider2D swordCollider;
//    [SerializeField] int swordDamage = 3;

//    private void Start()
//    {
//        swordCollider = GetComponent<Collider2D>();
//        rightAttackOffset = transform.position;
//    }

//    public void AttackRight()
//    {
//        print("Attack Right");
//        swordCollider.enabled = true;
//        transform.localPosition = rightAttackOffset;
//    }

//    public void AttackLeft()
//    {
//        print("Attack Left");
//        swordCollider.enabled = true;
//        transform.localPosition = new Vector3(-rightAttackOffset.x, rightAttackOffset.y);
//    }

//    public void StopAttack()
//    {
//        swordCollider.enabled = false;
//    }

//    private void OnTriggerEnter2D(Collider2D enemyCollider)
//    {
//        if (enemyCollider.tag == "Enemy")
//        {
//            Enemy enemy = enemyCollider.GetComponent<Enemy>();

//            if (enemy != null)
//            {
//                enemy.Health -= swordDamage;
//                print("Enemy: " + enemy.health);
//            }
//        }
//    }
//}
