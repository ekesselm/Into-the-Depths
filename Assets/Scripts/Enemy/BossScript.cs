using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float tiempoAtaque = 0.60f;
    public bool isAttacking = false;

    public SpriteRenderer mySpriteRenderer;

    private int siSaleUnoSalto;

    public Vector3 target;

    private Animator bossAnim;
    private Rigidbody2D bossRB;
    private RigidbodyType2D bodyType;

    public Transform Limite1;
    public Transform Limite2;

    public CapsuleCollider2D colDormido;
    public CapsuleCollider2D col1;
    public CircleCollider2D col2;

    public bool sleep;

    public bool puedoRodar;

    public bool haciaElPrimero;

    public bool movingRight;

    public int determinanteDerecha;
    public bool saltoVoyQueSaltoSalto;

    public bool canAttack;

    public int puedoHacermeBola;

    public bool noSaltesMas;

    public GameObject player;
    public Animator playerAnim;

    public Vector3 AquiSalto;
    public Vector3 posSalto;

    public bool voyaCaer;

    public float fuerzaEmpujon;

    public Health playerHealth;
    public float lockPlayerSeconds = 1f;


    public bool movimientoDer;
    public bool movimientoIzq;

 

    // Start is called before the first frame update

    void Start()
    {
        noSaltesMas = true;
        posSalto.y = -70;
        AquiSalto.y = -81;
        voyaCaer = false;
        saltoVoyQueSaltoSalto = false;
        bossAnim = gameObject.GetComponent<Animator>();
        bossRB = gameObject.GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        bossAnim.SetBool("sleep", true);
        sleep = true;
        movimientoDer = false;
        movimientoIzq = false;
}

    private void Ataque()
    {
        if (canAttack){

        //StartCoroutine("RetardoVida");
        bossAnim.SetBool("ataqueCerca", true);
        StartCoroutine("tiempoEsperaAtaque");

        movingRight = true;
        Vector2 direction = Vector2.left;
        if (movingRight) direction = Vector2.right;

            // Empujón
            //player.GetComponent<Movement>().ReceiveAttack(lockPlayerSeconds);
            //player.GetComponent<Rigidbody2D>().AddForce(direction * fuerzaEmpujon, ForceMode2D.Impulse);     
        }
    }

    private void Saltito()
    {
        if (movimientoDer) {

            determinanteDerecha = 0;

        } else if (movimientoIzq == false)
        {
            determinanteDerecha = Random.Range(0, 2);
        }

        if (movimientoIzq)
        {

            determinanteDerecha = 1;

        }
        else if (movimientoDer == false)
        {
            determinanteDerecha = Random.Range(0, 2);
        }

        //salto a la derecha
        if (determinanteDerecha == 0){

        Debug.Log("DESPEGUE");

            AquiSalto.x = (Random.Range(transform.position.x + 5f, transform.position.x + 9f));
            posSalto.x = (AquiSalto.x + transform.position.x) / 2;
            AquiSalto.y = -81;
            saltoVoyQueSaltoSalto = true;
            StartCoroutine("CooldownSalto");


        }

        if (determinanteDerecha == 1)
        {

            Debug.Log("DESPEGUE");
            AquiSalto.x = (Random.Range(transform.position.x - 5f, transform.position.x - 9f));
            posSalto.x = (AquiSalto.x + transform.position.x) / 2;
            AquiSalto.y = -81;
            saltoVoyQueSaltoSalto = true;
            StartCoroutine("CooldownSalto");

        }
    }

    IEnumerator CooldownSalto()
    {
        noSaltesMas = false;
        yield return new WaitForSecondsRealtime(1f);
        noSaltesMas = true;
    }

    IEnumerator RetardoVida()
    {
        if (canAttack) {

            playerAnim.SetBool("playerHit", true);
            playerHealth.Life -= 1;
            //new WaitForSeconds(1f);
            yield return new WaitForSeconds(0.13f);
            playerAnim.SetBool("playerHit", false);
        }
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
      if (sleep == false) { 
        if (col.transform.CompareTag("Player"))
        {
            //float esperaParaAtacar = Random.Range(1f, 4f);
            Invoke("Ataque", Random.Range(1f, 4f));
        }
      }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (sleep == false)
        {
            if (col.transform.CompareTag("Player"))
            {
                canAttack = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        bossAnim.SetBool("ataqueCerca", false);
        canAttack = false;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        //Para que, cuando choque con el player, se despierte. 

        if (Input.GetKey(KeyCode.Q))
        {
            sleep = false;
            bossAnim.SetBool("sleep", false);
        }
    }

    private void FixedUpdate()
    {

        if (sleep == false && siSaleUnoSalto != 1 && puedoRodar == false)
        {
            puedoHacermeBola = Random.Range(0, 300);
        }
        
        if (puedoRodar)
        {
            haciaElPrimero = true;
            transform.Rotate(0, 0, 30);
            if (haciaElPrimero)
            {
                if (transform.position == Limite1.position)
                {
                    target = Limite2.position;
                }

                if (transform.position == Limite2.position)
                {
                    target = Limite1.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, target, 0.3f);

            }

        }

        if (sleep == false && noSaltesMas == true && puedoHacermeBola != 1 && puedoRodar == false){
            siSaleUnoSalto = Random.Range(0, 100);
        }
    }
    void Update()
    {
        if (puedoHacermeBola == 1) {
            AtaqueBola();
            puedoHacermeBola = 3;
        }

        if (siSaleUnoSalto == 1)
        {
            siSaleUnoSalto = 3;
            Saltito();
        }

        TurnTowardsPlayer();

        if (saltoVoyQueSaltoSalto)
        {
            transform.position = Vector3.MoveTowards(transform.position, posSalto, 1);
        }


        if (transform.position == posSalto)
        {
            saltoVoyQueSaltoSalto = false;
            voyaCaer = true;
        }

        if (voyaCaer)
        {
            transform.position = Vector3.MoveTowards(transform.position, AquiSalto, 1);

            if (transform.position == AquiSalto)
            {
                voyaCaer = false;
            }
        }
        
        if (sleep)
        {
            bossRB.bodyType = RigidbodyType2D.Static;
            col1.enabled = false;
            col2.enabled = false;
            colDormido.enabled = true;
        } else {
 
            bossRB.bodyType = RigidbodyType2D.Kinematic;
            col1.enabled = true;
            col2.enabled = true;
            colDormido.enabled = false;
        }
    }

    private void AtaqueBola()
    {
        bossAnim.SetBool("ballAttack", true);
        puedoRodar = true;
        StartCoroutine("cdbola");
        target = Limite1.position;
    }

    public void TurnTowardsPlayer()
    {
        if (sleep == false && puedoRodar == false) { 
            if (transform.position.x > player.transform.position.x) // El player está a la IZQUIERDA
            {
                transform.eulerAngles = new Vector3(0, -180);
            }
            else if (transform.position.x < player.transform.position.x) // El player está a la DERECHA
            {
                transform.eulerAngles = new Vector3(0, 0);
        }
      }

    }
    IEnumerator cdbola(){
        Debug.Log("aaaaaaaaaaaaaa");
        yield return new WaitForSecondsRealtime(4f);
        bossAnim.SetBool("ballAttack", false);
        puedoRodar = false;
    }
}
