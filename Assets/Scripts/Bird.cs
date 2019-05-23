using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Animator BirdieAnimator;
    public bool PlayerisNear;

    // Start is called before the first frame update
    void Start()
    {
        BirdieAnimator = gameObject.GetComponent<Animator>();
    }

   void Vuelo()
    {
        BirdieAnimator.SetBool("PlayerNear", true);
        PlayerisNear = true;
    }

    void Die()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
