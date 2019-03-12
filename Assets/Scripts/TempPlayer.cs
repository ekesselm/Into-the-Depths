using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    public Animator player;
    public int player_speed;
    public int jump_force;
    public int vida;
    public bool low_health;
    public SpriteRenderer sprt_player;
    public Rigidbody2D rb;

         void Start()
    {
        player = GetComponent<Animator>();
        sprt_player = GetComponent<SpriteRenderer> ();
        sprt_player.flipX = false;
        rb = GetComponent<Rigidbody2D>();
        vida = 100;
    }

    void Update()
    {
        if (vida <= 25)
        {
            player.SetBool("low health", true);
            low_health = true;
        }
        
         if (vida > 25)
        {
            player.SetBool("low health", false);
            low_health = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.SetBool("ataque", true);
        } 
        
        if (Input.GetKeyUp(KeyCode.Q))
        {
            player.SetBool("ataque", false);
        }
        
        if (Input.GetKey(KeyCode.E))
        {
        
            player.SetBool("ataque up", true);

        }
         
        if (Input.GetKeyUp(KeyCode.E))
        {
          player.SetBool("ataque up", false);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(player_speed, 0) * Time.deltaTime);
            player.SetBool("andar", true);
            sprt_player.flipX = false;

        }
         
        if (Input.GetKeyUp(KeyCode.D))
        {
          player.SetBool("andar", false);

        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-player_speed, 0) * Time.deltaTime);
            player.SetBool("andar", true);
            sprt_player.flipX = true;
        }
        
        if (Input.GetKeyUp(KeyCode.A))
        {
          player.SetBool("andar", false);

        } 
         

        if (Input.GetKey(KeyCode.W))
        {
          rb.AddForce(new Vector2(0, jump_force), ForceMode2D.Impulse);
          player.SetBool("saltar", true);
          sprt_player.flipX = false;

            if (Input.GetKey(KeyCode.Q))
                player.SetBool("ataque", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            player.SetBool("saltar", false);

        }

    }
} 
