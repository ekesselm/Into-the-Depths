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
    public bool notJumping;

    private Animator animator;
    private float moveInput;
    private float jumpInput;
    private bool locked;
    private float jumpTimeCounter = 0f;

    private bool needPressJumpButtonAgain;
    private bool canJump;


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
    }

    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGround);
        canJump = isGrounded && jumpInput > 0 && !needPressJumpButtonAgain;

        if (canJump)
        {
            needPressJumpButtonAgain = true;
            notJumping = true;
            jumpTimeCounter = jumpTime;
        }
        
        if (notJumping && jumpInput > 0)
        {
            canJump = false;
            if (jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= 1*Time.deltaTime;
            } else {
                notJumping = false;
            }
        }

        // Restart jump
        if (jumpInput == 0) needPressJumpButtonAgain = false;

        MoveAnimation();
        
    }
    private void MoveAnimation()
    {

        animator.SetBool("andar", moveInput != 0f);

        animator.SetBool("saltar", jumpInput != 0f && canJump);

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
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

