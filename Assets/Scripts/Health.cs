using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    public int Life = 100;
    private int startLife;
    private Animator animator;
    
    public void Damage(int damage)
    {
        Life -= damage;

        if (Life <= startLife / 4)
        {
            animator.SetBool("lowHealth", true);
        }

        if (Life <= 0)
        {
            
        Destroy(gameObject);
        }
        Debug.Log(Life);
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        startLife = Life;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
