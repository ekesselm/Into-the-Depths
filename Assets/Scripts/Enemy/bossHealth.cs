using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    public int bossLife = 10;
    private Animator EnemyAnim;
    private GameObject player;

    public void Die()
    {

        Destroy(gameObject);

    }

    /// Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
    }
    
    /*
    private void OnTriggerEnter2D(Collision2D collision)
    {
        if (player)
        {
            bossLife = bossLife - 1;
            EnemyAnim.SetBool("hit", true);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        if (bossLife <= 0) { 

            EnemyAnim.SetBool("muerte", true);
        }
    }
}
