using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Animator BirdieAnimator;
    public bool PlayerisNear;
    public Vector2 target;
    public int step;

    // Start is called before the first frame update
    void Start()
    {
        BirdieAnimator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            Vuelo();

        }
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
        if (PlayerisNear)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
    }
}
