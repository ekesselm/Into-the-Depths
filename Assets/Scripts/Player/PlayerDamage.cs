using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private Animator playerAnimator;
    private int playerDamage = 1;
    private bool recibeDano;

    private GameObject enemy;

    public int bloqueoAtaque;
    public float fuerzaEmpujon;
    public GameObject player;

    public GameObject Limit;

    IEnumerator RetardoAtaque()
    {
        yield return new WaitForSeconds(0.5f);
        enemy.GetComponent<Animator>().SetBool("hit", false);
    }

    public void PlayerAttacks()
    {
        playerAnimator.SetBool("ataque", false);
        if (enemy) { 
            enemy.GetComponent<Animator>().SetBool("hit", true);
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
            if (enemyHit) enemy = enemyHit.collider.gameObject;
            playerAnimator.SetBool("ataque", true);
        }

    }
}  