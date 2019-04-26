using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limita : MonoBehaviour
{
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        //playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.transform.tag == "Player")
        {
            playerAnim.SetBool("andar", false);
            playerAnim.SetBool("saltar", false);
        }
    }
}
