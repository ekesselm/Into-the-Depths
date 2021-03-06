﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyLife = 3;
    private Animator EnemyAnim;
    private Rigidbody2D rb;

    public GameObject feathers;
    public ParticleSystem featherParticle;

    public BossScript scriptDelBoss;
    public GameObject boss;

    public bool featherSpawn;

    public int numSaltos = 3;

    public AudioSource enemy1Death;
    public AudioSource damageEnemy1;

    public bool IsAttackPossible;
    public bool suenaSonidoMuerte;

    public AudioSource musicaBoss;
    public AudioSource musicaBG;
    public AudioSource sonidoMuerteBoss;

    public void Die()
    {

        Destroy(gameObject);

    }

    public void sonidoDieBoss()
    {
        sonidoMuerteBoss.Play();
    }

    public void sonidoDie()
    {

        enemy1Death.Play();

    }

    public void sonidoDamage()
    {

        damageEnemy1.Play();

    }

    // Start is called before the first frame update

    void Start()
    {
        suenaSonidoMuerte = false;
        IsAttackPossible = true;
        feathers = GameObject.Find("Feathers");
        featherSpawn = false;
        EnemyAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (gameObject.name.Contains("Aire")) {

        if (collision.transform.CompareTag("Ground") && enemyLife <= 0)
        {
                numSaltos += 1;

                if (numSaltos <= 3) { 
                rb.bodyType = RigidbodyType2D.Static;                 
                }
            }
      }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name.Contains("Tierra")) {

            if (enemyLife <= 0)
            {
            GetComponent<EnemyGroundMovement>().dead = true;
            EnemyAnim.SetBool("muerte", true); 
            }
        }

        if (gameObject.name.Contains("Boss"))
        {
            if (enemyLife <= 0)
            {
                scriptDelBoss.noSaltesMas = false;
                scriptDelBoss.puedoHacermeBola = 0;
                scriptDelBoss.canAttack = false;
                scriptDelBoss.isDead = true;
                musicaBoss.Stop();
                EnemyAnim.SetBool("muerte", true);
                transform.gameObject.tag = "Untagged";
                musicaBG.Play();

            }
        }

        if (gameObject.name.Contains("Aire"))
        {
            if (enemyLife <= 0)
            {
                EnemyAnim.SetBool("muerte", true);
                GetComponent<Rigidbody2D>().gravityScale = 9.8f;
                GetComponent<AirEnemy>().enabled = false;
                rb.constraints = RigidbodyConstraints2D.None;
                Destroy(GetComponent<AirEnemy>());
                featherSpawn = true;

            }

        }

        if (featherSpawn == true)
        {
            featherParticle.Play();
        } 
    }
}
