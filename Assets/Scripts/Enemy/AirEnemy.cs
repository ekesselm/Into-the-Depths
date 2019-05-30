using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
    private Vector2 playerPos;
    private Vector2 actualPosition;


    private Vector2 lastPosition;

    public GameObject player;

    private Rigidbody2D rb;
    private CircleCollider2D PlayerDetectionCollider;

    public Transform Limit;
    public float speed;

    private int layerGround;

    private bool movingRight = true;
    public bool dead;

    public Animator Enemy2Anim;

    public bool isAttacking = false;
    public bool isStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        layerGround = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
        PlayerDetectionCollider = GetComponent<CircleCollider2D>();
        Enemy2Anim = gameObject.GetComponent<Animator>();
    }

    public bool HasToRotate()
    {
        return !Physics2D.Raycast(Limit.position, Vector2.down, 2f).collider ||
            Physics2D.Raycast(Limit.position, Vector2.right, 2f, LayerMask.GetMask("Ground")).collider ||
            Physics2D.Raycast(Limit.position, Vector2.left, 2f, LayerMask.GetMask("Ground")).collider;
    }

    public bool isMovingRight()
    {
        return movingRight;
    }

    private void RotateRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        movingRight = true;
    }

    private void RotateLeft()
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        movingRight = false;
    }

    public void TurnTowardsPlayer(GameObject player)
    {
        if (dead == false)
        {
            if (transform.position.x > player.transform.position.x && !HasToRotate()) // El player está a la IZQUIERDA
            {
                RotateLeft();
            }
            else if (transform.position.x < player.transform.position.x && !HasToRotate()) // El player está a la DERECHA
            {
                RotateRight();
            }

        }
    }

    private void Movement()
    {
        if (dead) return;
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (HasToRotate())
        {
            if (movingRight)
            {
                RotateLeft();
            }
            else
            {
                RotateRight();
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(Limit.position, Vector2.right, 0.6f, layerGround);
        if (hit.collider)
        {
            Debug.Log(hit.transform.gameObject.name);
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
    IEnumerator esperaCollider()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, lastPosition, step);
        yield return new WaitForSeconds(2f);
        PlayerDetectionCollider.enabled = true;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerDetectionCollider.enabled = !PlayerDetectionCollider.enabled;
        StartCoroutine(esperaCollider());

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
            {
            
            Enemy2Anim.SetBool("playerAround", true);
            isAttacking = true;
            playerPos = collision.transform.position;
            TurnTowardsPlayer(player);
            //actualPosition = playerPos - actualPosition;
            //transform.rotation = playerPos - actualPosition;
            //transform.LookAt(playerPos);

            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, playerPos, step);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isAttacking = false;
        Enemy2Anim.SetBool("playerAround", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
            Movement();

        actualPosition = transform.position;

        if (!isAttacking)
            Movement();

        //if (!dead)
          //  rb = null;
        

    }
}
