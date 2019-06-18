using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;

    public bool isGrounded;

    public Transform feetPos;

    public float checkRadius;
    public LayerMask whatisGround;
    public float jumpTime;

    private Animator animator;
    private float moveInput;
    private float jumpInput;
    private bool locked;
    private float jumpTimeCounter = 0f;

    private bool needPressJumpButtonAgain;
    private bool canJump;
    private Vector2 direction;

    public GameObject dustEffect;
    public bool spawnDust;

    public bool dustLimiter;

    public AudioSource sonidoAndar;
    public AudioSource JumpSound;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        locked = false;

    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        jumpInput = Input.GetAxisRaw("Vertical");

        if (!locked) rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //particles

        if (isGrounded == true)
        {

            if (spawnDust == true && dustLimiter == true)
            {
                Instantiate(dustEffect, feetPos.position, Quaternion.identity);
                spawnDust = false;
            }


        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dustLimiter = true;

        ///////////////////////////////////////////////////////////////////////////
        /*
        if (collision.gameObject.tag == "Ground")
        {
            LandSound.Play();
        }*/
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        dustLimiter = true;

        if (moveInput < 0)
        {
            spawnDust = true;
        }

        if (moveInput > 0)
        {
            spawnDust = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        dustLimiter = false;

        if (jumpInput < 0){

            isGrounded = false;
        }
    }

    void Update() {

        canJump = IsGrounded() && jumpInput > 0 && !needPressJumpButtonAgain;
        MoveAnimation();

        if (canJump)
        {
            needPressJumpButtonAgain = true;
            jumpTimeCounter = jumpTime;
        }
        
        if (jumpInput > 0 && isGrounded && needPressJumpButtonAgain)
        {
            Instantiate(dustEffect, feetPos.position, Quaternion.identity);
            animator.SetBool("saltar", true);

            if (jumpTimeCounter > 0){

                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= 1*Time.deltaTime;
                spawnDust = true;
            } 
        }
        else
        {
            animator.SetBool("saltar", false);
            needPressJumpButtonAgain = false;
        }

        // Restart jump
        if (jumpInput == 0) needPressJumpButtonAgain = false;
    }

    private void MoveAnimation()
    {
        //Debug.Log("canJump " + canJump);
        //Debug.Log("jumpInput " + (jumpInput != 0f));
        animator.SetBool("andar", moveInput != 0f);
        animator.SetBool("saltar", jumpInput != 0f && canJump);
       

        if (Input.GetKeyDown(KeyCode.A))
        {
            sonidoAndar.Play();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            sonidoAndar.Pause();
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            sonidoAndar.Play();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            sonidoAndar.Pause();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            JumpSound.Play();
        }

        if (moveInput > 0)
        {
            direction = Vector2.right;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            direction = Vector2.left;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public Vector2 GetDirection()
    {
        return direction;
    }

    public void ReceiveAttack(float lockedSeconds)
    {
        locked = true;
        Invoke("Unlock", lockedSeconds);

    }

    private void Unlock()
    {
        locked = false;
    }

    public bool IsMoving()
    {
        return moveInput != 0 || jumpInput != 0;
    }
}

