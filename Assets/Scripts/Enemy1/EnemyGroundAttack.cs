﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyGroundMovement))]
public class EnemyGroundAttack : MonoBehaviour
{

    public float tiempoAtaque = 0.60f;
    
    public float fuerzaEmpujon;

    public int enemyDamage = 25;

    private GameObject player;
    private Animator Enemy1Animator;
    
    public void Empujon()
    {
        if (player)
        {
            bool movingRight = GetComponent<EnemyGroundMovement>().isMovingRight();
            Vector2 direction = Vector2.left;
            if (movingRight) direction = Vector2.right;
            player.GetComponent<Rigidbody2D>().AddForce(direction * fuerzaEmpujon, ForceMode2D.Impulse);
            Debug.Log("Movimiento a la derecha " + movingRight);
        }
    }

    void Start()
    {
        Enemy1Animator = gameObject.GetComponent<Animator>();

    }

    IEnumerator tiempoEsperaAtaque()
    {
        yield return new WaitForSeconds(tiempoAtaque);
        GetComponent<EnemyGroundMovement>().isAttacking = false;

    }

    void OnTriggerEnter2D(Collider2D col){
    
        if (col.transform.CompareTag("Player")){
                Debug.Log("enemy detected");
                Enemy1Animator.SetBool("atacar", true);
                GetComponent<EnemyGroundMovement>().isAttacking = true;
                player = col.gameObject;
                StartCoroutine("tiempoEsperaAtaque");
                player.GetComponent<Health>().Damage(enemyDamage);

            }
        }

    void OnTriggerExit2D(Collider2D col)
    {
        Enemy1Animator.SetBool("atacar", false);
    }

}



  

