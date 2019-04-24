using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    public Animator player;
    public int speed;
	public int jumpForce;
    public SpriteRenderer sprt_player;
    public Rigidbody2D rb;

         void Start()
    {
        player = GetComponent<Animator>();
        sprt_player = GetComponent<SpriteRenderer> ();
        sprt_player.flipX = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
	{

        

		if (Input.GetKeyUp (KeyCode.Q)) {
			player.SetBool ("ataque", false);
		}
        
		if (Input.GetKey (KeyCode.E)) {
        
			player.SetBool ("ataque up", true);

		}
         
		if (Input.GetKeyUp (KeyCode.E)) {
			player.SetBool ("ataque up", false);

		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (new Vector2 (speed, 0) * Time.deltaTime);
			player.SetBool ("andar", true);
			sprt_player.flipX = false;

		}
         
		if (Input.GetKeyUp (KeyCode.D)) {
			player.SetBool ("andar", false);

		}


		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (new Vector2 (-speed, 0) * Time.deltaTime);
			player.SetBool ("andar", true);
			sprt_player.flipX = true;
		}
        
		if (Input.GetKeyUp (KeyCode.A)) {
			player.SetBool ("andar", false);

		} 
         

		if (Input.GetKey (KeyCode.W)) {
			rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
			player.SetBool ("saltar", true);
			sprt_player.flipX = false;



			if (Input.GetKeyUp (KeyCode.W)) {
				player.SetBool ("saltar", false);

			}

		}
	}
}
