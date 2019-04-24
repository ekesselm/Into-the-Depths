using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    
	public Animator player;

    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;  

    private float moveInput;

    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatisGround;

    public float jumpTimeCounter;
    public float jumpTime;
    public bool isJumping;


    void Start() {
        
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
       moveInput = Input.GetAxisRaw("Horizontal");
       rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }

    void Update() {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGround);

        if (Input.GetKeyDown(KeyCode.Q))
		{
			player.SetBool("ataque", true);
		} 

		if (Input.GetKeyUp(KeyCode.Q))
		{
			player.SetBool("ataque", false);
		}


        if (moveInput > 0){

         transform.eulerAngles = new Vector3(0,0,0);
			player.SetBool("andar", true);
        
		} else if (moveInput < 0) {

        transform.eulerAngles = new Vector3(0,180,0);
			player.SetBool("andar", true);
        }

		if (Input.GetKeyUp(KeyCode.A))
		{
			player.SetBool("andar", false);
		}

		if (Input.GetKeyUp(KeyCode.D))
		{
			player.SetBool("andar", false);
		}

        if (isGrounded == true && Input.GetKeyDown(KeyCode.W)){
           isJumping = true;
		    player.SetBool("saltar", true);
           jumpTimeCounter = jumpTime;
           rb.velocity = Vector2.up * jumpForce;
        }

        if (!isJumping && isGrounded == true)
        {

            player.SetBool("saltar", false);

        }

        if (Input.GetKey(KeyCode.W) && isJumping == true){
         
        if(jumpTimeCounter > 0){
            
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= 1*Time.deltaTime;

            } else {
            isJumping = false;

           }

        }

         if(Input.GetKeyUp(KeyCode.W)){
            isJumping = false;

         }

        }

    }
