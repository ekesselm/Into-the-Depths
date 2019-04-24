using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    public int Life = 4;
    private Animator animator;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;

    Scene escenaActual;

    void Start()
    {
        animator = GetComponent<Animator>();
        escenaActual = SceneManager.GetActiveScene();
    }

    void Update()
    {

        if (Life == 4)
        {
           c4.SetActive(true);
           c3.SetActive(true);
           c2.SetActive(true);
           c1.SetActive(true);
        } 

        if (Life == 3)
        {
            c4.SetActive(false);
            c3.SetActive(true);
            c2.SetActive(true);
            c1.SetActive(true);
        }


        if (Life == 2)
        {
            c4.SetActive(false);
            c3.SetActive(false);
            c2.SetActive(true);
            c1.SetActive(true);
        }


        if (Life == 1)
        {
            c4.SetActive(false);
            c3.SetActive(false);
            c2.SetActive(false);
            c1.SetActive(true);
            animator.SetBool("lowHealth", true);
        }


        if (Life <= 0)
        {

            SceneManager.LoadScene(escenaActual.name);

        }
        Debug.Log(Life);
    }


 
    void actualizaUI()
    {
        
    }

 
}
