using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyLife = 3;
    private Animator EnemyAnim;
    private Rigidbody2D rb;

    public GameObject feathers;
    public ParticleSystem featherParticle;

    public bool featherSpawn;

    public int numSaltos = 3;

    public void Die()
    {

        Destroy(gameObject);

    }


    // Start is called before the first frame update

    void Start()
    {
        feathers = GameObject.Find("Feathers");
        featherSpawn = false;
        EnemyAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (gameObject.name.Contains("Aire")) {

        if (collision.transform.CompareTag("Ground") && enemyLife <= 0)
        {
                numSaltos += 1;

                if (numSaltos <= 3) { 
                rb.bodyType = RigidbodyType2D.Static;                 
                }
            }
      }
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.name.Contains("Tierra")) { 
            if (enemyLife <= 0)
            {
            GetComponent<EnemyGroundMovement>().dead = true;
            EnemyAnim.SetBool("muerte", true); 
            }
        }

        if (gameObject.name.Contains("Aire"))
        {
            if (enemyLife <= 0)
            {
                EnemyAnim.SetBool("muerte", true);
                GetComponent<Rigidbody2D>().gravityScale = 9.8f;
                GetComponent<AirEnemy>().enabled = false;
                rb.constraints = RigidbodyConstraints2D.None;
                Destroy(GetComponent<AirEnemy>());
                featherSpawn = true;

            }

        }

        if (featherSpawn == true)
        {
            featherParticle.Play();
        } 
    }
}
