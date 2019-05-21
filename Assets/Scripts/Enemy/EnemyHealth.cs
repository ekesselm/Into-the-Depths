using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyLife = 2;
    private Animator EnemyAnim;

    public void DieBitch()
    {

        Destroy(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        enemyLife = 2;
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyLife <= 0)
        {

            EnemyAnim.SetBool("muerte", true); 

        }
    }
}
