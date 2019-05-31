using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
    public Vector3 OriginalPos;
    public Vector3 target;
    public Vector3 playerPos;

    public Health playerHealth;

    public bool Attacking;

    public bool AttackCheck;

    public GameObject player;

    public int speed;

    private void Start()
    {
        OriginalPos = transform.position;
        target = OriginalPos;
       
        AttackCheck = false;
        Attacking = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")){
            AttackCheck = false;
            playerHealth.Life -= 1;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && Attacking)
        {
            StartCoroutine("CooldownAtaque");
            StartCoroutine("CooldownDos");
            AttackCheck = true;
            playerPos = player.transform.position;
            target = playerPos;

        }
    }


        IEnumerator CooldownDos()
    {
        yield return new WaitForSecondsRealtime(1f);
        AttackCheck = false;
    }

    IEnumerator CooldownAtaque()
    {
        Attacking = false;
        yield return new WaitForSecondsRealtime(3f);
        Attacking = true;

    }

    private void FixedUpdate()
    {
        if (Attacking == false && AttackCheck == false)
        {
            target = OriginalPos;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed);

    }
}
