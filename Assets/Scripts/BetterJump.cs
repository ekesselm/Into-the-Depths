using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 4f;

    Rigidbody2D Impulso;

    void Awake () {
    	Impulso = GetComponent<Rigidbody2D> ();
    }

    void FixedUpdate (){
    	if (Impulso.velocity.y < 0) {
    		Impulso.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    	} else if (Impulso.velocity.y > 0 && !Input.GetButtonDown("Jump")) {
          Impulso.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
