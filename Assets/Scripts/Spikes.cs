using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public float fuerzaEmpujon;

    public int enemyDamage = 1;

    public float lockPlayerSeconds = 1f;

    public Health playerHealth;

    public void Empujon(GameObject player)
    {
            playerHealth.hurtSound.Play();
            player.GetComponent<Movement>().ReceiveAttack(lockPlayerSeconds);
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaEmpujon, ForceMode2D.Impulse);
            Debug.Log("Fuerza aplicada");
    }



    IEnumerator tiempoEsperaAtaque()
    {
        new WaitForSeconds(2f);
        yield return new WaitForSeconds(0.1f);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("PINCHOS BITCH!");

        if (col.transform.tag == "Player")
        {
            Empujon(col.gameObject);
            StartCoroutine("tiempoEsperaAtaque");
            playerHealth.Life -= enemyDamage;

        }
    }
}
