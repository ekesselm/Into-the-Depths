using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public BoxCollider2D colTop;
    public BoxCollider2D colSide;

    private Animator playerAnimator;
    private int playerDamage = 1;
    public bool recibeDano;

    private GameObject enemy;

    public int bloqueoAtaque;
    public float fuerzaEmpujon;
    public GameObject player;

    public GameObject Limit;

    public AudioSource sonidoAtaque1;
    public AudioSource sonidoAtaque2;

    private EnemyHealth scriptVidaEnem;

    public AudioSource sonidoDamageBoss;
    public AudioClip clipSonidoDamageBoss;

    IEnumerator RetardoAtaque()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        enemy.GetComponent<Animator>().SetBool("hit", false);
    }

    public void PlayerAttacksTop()
    {
        colTop.enabled = true;
        colSide.enabled = false;

        playerAnimator.SetBool("ataque up", false);

        if (enemy && scriptVidaEnem.IsAttackPossible)
        {
            enemy.GetComponent<Animator>().SetBool("hit", true);
            sonidoDamageBoss.PlayOneShot(clipSonidoDamageBoss);
            enemy.GetComponent<EnemyHealth>().enemyLife = enemy.GetComponent<EnemyHealth>().enemyLife - playerDamage;
            StartCoroutine(RetardoAtaque());

        }

       }


    public void PlayerAttacksSide()
    {
        colSide.enabled = true;
        colTop.enabled = false;
        playerAnimator.SetBool("ataque", false);

        if (enemy && scriptVidaEnem.IsAttackPossible) {

            enemy.GetComponent<Animator>().SetBool("hit", true);
            sonidoDamageBoss.PlayOneShot(clipSonidoDamageBoss);
            enemy.GetComponent<EnemyHealth>().enemyLife = enemy.GetComponent<EnemyHealth>().enemyLife - playerDamage;
            StartCoroutine(RetardoAtaque());

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Enemy")) recibeDano = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        recibeDano = false;
    }


    void Start()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaycastHit2D enemyHit = Physics2D.Raycast(Limit.transform.position, GetComponent<Movement>().GetDirection(), 2f, LayerMask.GetMask("Enemy"));
            Debug.DrawRay(Limit.transform.position, GetComponent<Movement>().GetDirection(), Color.green);

            if (enemyHit)
            {
                enemy = enemyHit.collider.gameObject;
                scriptVidaEnem = enemy.GetComponent<EnemyHealth>();
            }
            
            playerAnimator.SetBool("ataque", true);
            sonidoAtaque1.Play();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D enemyHit = Physics2D.Raycast(Limit.transform.position, GetComponent<Movement>().GetDirection(), 2f, LayerMask.GetMask("Enemy"));
            Debug.DrawRay(Limit.transform.position, GetComponent<Movement>().GetDirection(), Color.green);

            if (enemyHit)
            {
                enemy = enemyHit.collider.gameObject;
                scriptVidaEnem = enemy.GetComponent<EnemyHealth>();
            }

            playerAnimator.SetBool("ataque up", true);
            sonidoAtaque2.Play();

        }
    }

}