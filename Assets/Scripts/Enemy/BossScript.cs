using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float tiempoAtaque = 0.60f;
    public bool isAttacking = false;

    public SpriteRenderer mySpriteRenderer;


    private Animator bossAnim;
    private Rigidbody2D bossRB;
    private RigidbodyType2D bodyType;

    public bool sleep;
    public bool awake;

    public GameObject player;
    public Animator playerAnim;

    public float fuerzaEmpujon;

    public Health playerHealth;
    public float lockPlayerSeconds = 1f;


    private bool movingRight = true;

    // Start is called before the first frame update

    void Start()
    {
        bossAnim = gameObject.GetComponent<Animator>();
        bossRB = gameObject.GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        bossAnim.SetBool("sleep", true);

    }

    private void Ataque()
    {
        //StartCoroutine("RetardoVida");
        bossAnim.SetBool("ataqueCerca", true);
        StartCoroutine("tiempoEsperaAtaque");

        movingRight = true;
        Vector2 direction = Vector2.left;
        if (movingRight) direction = Vector2.right;
        
        // Empujón
        player.GetComponent<Movement>().ReceiveAttack(lockPlayerSeconds);
        player.GetComponent<Rigidbody2D>().AddForce(direction * fuerzaEmpujon, ForceMode2D.Impulse);     

    }


    IEnumerator RetardoVida()
    {
        new WaitForSeconds(1f);
        playerHealth.Life -= 1;
        playerAnim.SetBool("playerHit", false);
        yield return new WaitForSeconds(0.1f);

    }

    IEnumerator tiempoEsperaAtaque()
    {
        yield return new WaitForSeconds(1f);
        bossAnim.SetBool("ataqueCerca", false);
        isAttacking = false;
        yield return new WaitForSeconds(0.3f);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.transform.CompareTag("Player"))
        {
            //float esperaParaAtacar = Random.Range(1f, 4f);
            Invoke("Ataque", Random.Range(1f, 4f));
            playerAnim.SetBool("playerHit", true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        bossAnim.SetBool("ataqueCerca", false);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Para que, cuando choque con el player, se despierte. 

        if (Input.GetKey(KeyCode.Q))
        {
            awake = true;
            bossAnim.SetBool("sleep", false);
        }
    }

    void Update()
    {
        if (sleep)
        {
            awake = false;
            bossRB.bodyType = RigidbodyType2D.Static;
        }

        if (awake)
        {
            sleep = false;
            bossRB.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    public void TurnTowardsPlayer(GameObject player)
    {

            if (transform.position.x > player.transform.position.x) // El player está a la IZQUIERDA
            {
                mySpriteRenderer.flipX = false;
        }
            else if (transform.position.x < player.transform.position.x) // El player está a la DERECHA
            {
                mySpriteRenderer.flipX = true;
        }

    }

}
