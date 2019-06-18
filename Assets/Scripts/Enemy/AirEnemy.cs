using System.Collections;
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
    public float lockPlayerSeconds = 0.5f;
    public Animator playerAnim;
    public bool movingRight;

    public bool Attacking;

    public bool GiraGira;

    public bool limitsLimiter;

    public bool AttackCheck;

    public GameObject player;

    public float speed;

    public Animator Enemy2Anim;

    public SpriteRenderer spriteRen;

    public AudioSource Enemy2Attack;

    public void Empujon()
    {
        // Detectar hacia que lado dar el empujón
        Vector2 direction = Vector2.right;
        if (movingRight) direction = Vector2.left;
        StartCoroutine("RetardoVida");
        // Empujón
        player.GetComponent<Movement>().ReceiveAttack(lockPlayerSeconds);
        player.GetComponent<Rigidbody2D>().AddForce(direction * 30, ForceMode2D.Impulse);
 

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

    IEnumerator RetardoVida()
    {
        new WaitForSecondsRealtime(4f);
        playerHealth.Life -= 1;
        Debug.Log("Entra");
        yield return new WaitForSeconds(0.1f);
        playerAnim.SetBool("playerHit", false);

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.transform.CompareTag("Player")){
            playerHealth.hurtSound.Play();
            playerAnim.SetBool("playerHit", true);
            Empujon();
            AttackCheck = false;
            limitsLimiter = true;
    
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerAnim.SetBool("playerHit", false);
        }
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

}
