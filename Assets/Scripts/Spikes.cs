using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public float fuerzaEmpujon;

    public int enemyDamage = 1;

    public float lockPlayerSeconds = 1f;

    public Health playerHealth;

    private GameObject player;

    public void Empujon()
    {
        if (player)
            {
            Vector2 direction = Vector2.up;
            player.GetComponent<Movement>().ReceiveAttack(lockPlayerSeconds);
            player.GetComponent<Rigidbody2D>().AddForce(direction * fuerzaEmpujon, ForceMode2D.Impulse);
            Debug.Log("PINCHOS BITCH!");
            }
    }



    IEnumerator tiempoEsperaAtaque()
    {
        new WaitForSeconds(1.5f);
        yield return new WaitForSeconds(0.1f);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("PINCHOS BITCH!");
        if (col.transform.tag ==("Player"))
            {
            Empujon();
            player = col.gameObject;
            StartCoroutine("tiempoEsperaAtaque");
            playerHealth.Life -= enemyDamage;

        }
        }
    }
