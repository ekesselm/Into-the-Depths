using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyGroundMovement))]
public class EnemyGroundAttack : MonoBehaviour
{

    public float tiempoAtaque = 0.60f;
    public float fuerzaEmpujon;
    public int enemyDamage = 1;
    public Health playerHealth;
    public float lockPlayerSeconds = 1f;

    private GameObject player;
    private Animator Enemy1Animator;
    
    public void Empujon()
    {
        // Detectar hacia que lado dar el empujón
        bool movingRight = GetComponent<EnemyGroundMovement>().isMovingRight();
        Vector2 direction = Vector2.left;
        if (movingRight) direction = Vector2.right;
        Debug.Log("Empujando a la derecha? " + movingRight);

        // Empujón
        player.GetComponent<Movement>().ReceiveAttack(lockPlayerSeconds);
        player.GetComponent<Rigidbody2D>().AddForce(direction * fuerzaEmpujon, ForceMode2D.Impulse);
        StartCoroutine("RetardoVida");
        
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

    IEnumerator RetardoVida()
    {
        new WaitForSeconds(1.5f);
        playerHealth.Life -= enemyDamage;
        yield return new WaitForSeconds(0.1f);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            Enemy1Animator.SetBool("atacar", true);
            GetComponent<EnemyGroundMovement>().isAttacking = true;
            player = col.gameObject;
            StartCoroutine("tiempoEsperaAtaque");

            //player.GetComponent<Health>().Damage(enemyDamage);
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        Enemy1Animator.SetBool("atacar", false);
    }

}



  

