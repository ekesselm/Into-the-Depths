using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_attack : MonoBehaviour
{
    public int tiempoAtaque = 1;

    Animator Enemy1Animator;

    public Rigidbody2D Player;

    public bool atacando;

    float speed;

    public GameObject PlayerPos;

    public Vector3 fuerzaEmpujon;

    public int distanciaEnemigo = 4;

    void Start(){

        Enemy1Animator = gameObject.GetComponent<Animator>();
        atacando = false;
    }

    IEnumerator tiempoEsperaAtaque(){
        speed = 0;
        yield return new WaitForSeconds(tiempoAtaque);
        Enemy1Animator.SetBool("detenerse", true);
        Enemy1Animator.SetBool("atacar", false);
        atacando = false;
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("enemy detected");
        atacando = true;
        Enemy1Animator.SetBool("atacar", true);
        StartCoroutine("tiempoEsperaAtaque");
        Player.AddForce(fuerzaEmpujon, ForceMode2D.Impulse);
    }
}
