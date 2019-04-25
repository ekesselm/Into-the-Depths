using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limita : MonoBehaviour
{
    public Animator player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.transform.tag == "Player")
        {
            player.SetBool("andar", false);
        }
    }
}
