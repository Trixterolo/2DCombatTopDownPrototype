//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyOld : MonoBehaviour
//{
//    Animator animator;
//    public int Health 
//    {
//        get { return health; }

//        set
//        {
//            health = value;
//            if (health <= 0)
//            {
//                Defeated();
//            }
//        }

//    }

//    public int health = 1;

//    private void Start()
//    {
//        animator= GetComponent<Animator>();
//    }

//    private void Defeated()
//    {
//        print("Enemy died");
//        animator.SetTrigger("Defeated");
        
//    }

//    private void RemoveEnemy()
//    {
//        print("Enemy removed");
//        Destroy(gameObject);
//    }
//}
