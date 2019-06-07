﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
    public Vector3 OriginalPos;
    public Vector3 target;
    public Vector3 playerPos;

    public bool dead;

    public Vector3 Limit1;
    public Vector3 Limit2;

    public Health playerHealth;
    public float lockPlayerSeconds = 1f;
    public Animator playerAnim;
    public bool movingRight;

    public bool Attacking;

    public bool GiraGira;

    public bool limitsLimiter;

    public bool AttackCheck;

    public GameObject player;

    public float speed;

    private Animator Enemy2Anim;

    private SpriteRenderer spriteRen;

    public void Empujon()
    {
        // Detectar hacia que lado dar el empujón
        Vector2 direction = Vector2.right;
        if (movingRight) direction = Vector2.left;

        // Empujón
        player.GetComponent<Movement>().ReceiveAttack(lockPlayerSeconds);
        player.GetComponent<Rigidbody2D>().AddForce(direction * 30, ForceMode2D.Impulse);
        StartCoroutine("RetardoVida");

    }

    private void Start()
    {

        Enemy2Anim = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
        OriginalPos = transform.position;
        target = OriginalPos;
        Limit1 = OriginalPos;
        AttackCheck = false;
        Attacking = true;
        limitsLimiter = true;

    }

    IEnumerator RetardoVida()
    {
        new WaitForSecondsRealtime(4f);
        playerHealth.Life -= 1;
        yield return new WaitForSeconds(0.1f);
        playerAnim.SetBool("playerHit", false);

    }

    private void OnCollisionStay2D(Collision2D collision) 
    {

        if (collision.transform.CompareTag("Player")){
            playerAnim.SetBool("playerHit", true);
            Empujon();
            AttackCheck = false;
            limitsLimiter = true;
    
        }
        
    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.transform.CompareTag("Player") && Attacking)
        {
            StartCoroutine("CooldownAtaque");
            StartCoroutine("CooldownDos");
            AttackCheck = true;
            playerPos = player.transform.position;
            target = playerPos;
   
        }

    }*/

   


        IEnumerator CooldownDos()
    {
        yield return new WaitForSecondsRealtime(1f);
        AttackCheck = false;
        Enemy2Anim.SetBool("playerAround", false);
        GiraGira = true;
        limitsLimiter = true;
    }

    IEnumerator CooldownAtaque()
    {
        Attacking = false;
        yield return new WaitForSecondsRealtime(3f);
        Attacking = true;

    }


    private void FixedUpdate()
    {
        if (GiraGira == true)
        {
            if (OriginalPos == Limit1)
            {
                spriteRen.flipX = true;
            }
            else
            {
                spriteRen.flipX = false;
            }
        }

        if (AttackCheck == false && limitsLimiter)
        {
            
            if (transform.position == Limit1)
            {
                OriginalPos = Limit2;
                movingRight = true;
                spriteRen.flipX = false;
                //limitsLimiter = false;
            }
            if (transform.position == Limit2)
            {
                OriginalPos = Limit1;
                spriteRen.flipX = true;
                movingRight = false;
                //limitsLimiter = false;
            }

            target = OriginalPos;
        }


        transform.position = Vector3.MoveTowards(transform.position, target, speed);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Player") && Attacking)
        {
            GiraGira = false; 
            StartCoroutine("CooldownAtaque");
            StartCoroutine("CooldownDos");
            AttackCheck = true;

            Enemy2Anim.SetBool("playerAround", true);

            playerPos = player.transform.position;
            target = playerPos;

            if (transform.position.x < player.transform.position.x && target == playerPos)
            {
                spriteRen.flipX = true;
            }
            else
            {
                spriteRen.flipX = false;
            }

        }
    }
}
