using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyDeath : MonoBehaviour
{
    public int enemyLife = 3;
    private Animator EnemyAnim;

    public void Die()
    {

        Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLife <= 0)
        {
            GetComponent<AirEnemy>().dead = true;
            EnemyAnim.SetBool("muerte", true);
        }
    }
}
