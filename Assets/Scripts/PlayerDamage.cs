using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    public int bloqueoAtaque;

    public float fuerzaEmpujon;

    public EnemyHealth vidaEnemigo;

    private Animator playerAnimator;

    public Animator Enemy1Anim;

    private int playerDamage = 1;

    public GameObject player;

    public GameObject Enemy;

    public bool recibeDaño;

    IEnumerator retardoAtaque()
    {
        yield return new WaitForSeconds(bloqueoAtaque);
        Enemy1Anim.SetBool("hit", false);
        vidaEnemigo.enemyLife = vidaEnemigo.enemyLife - playerDamage;

    }


    public void PlayerAttacks()
    {

        Enemy1Anim.SetBool("hit", true);
        StartCoroutine("retardoAtaque");
        playerAnimator.SetBool("ataque", false);
        //Enemy.GetComponent<Rigidbody2D>().AddForce(transform.up * fuerzaEmpujon, ForceMode2D.Impulse);


    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.transform.CompareTag("Enemy"))
        {

            recibeDaño = true;

        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        recibeDaño = false;
    }


    void Start()
    {

        playerAnimator = gameObject.GetComponent<Animator>();
        Enemy1Anim = Enemy.GetComponent<Animator>();


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerAnimator.SetBool("ataque", true);
        }

        if (recibeDaño == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) && recibeDaño == true)
            {
                playerAnimator.SetBool("ataque", true);
                Debug.Log(vidaEnemigo.enemyLife);
                PlayerAttacks();
                
                 
            }

        }

    }        
 }