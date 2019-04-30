using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyGroundAttack))]
public class EnemyGroundMovement : MonoBehaviour
{

    public Transform Limit;
    public float speed;
    public float distance;

    private int layerGround;

    public bool isAttacking = false;
    public bool isStopped = false;

    private bool movingRight = true;

    private void Start()
    {
        layerGround = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        if (!isAttacking)
            Movement();
    } 

    private void Movement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (!Physics2D.Raycast(Limit.position, Vector2.down, 2f).collider)
        {
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
        
        RaycastHit2D hit = Physics2D.Raycast(Limit.position, Vector2.right, 0.6f, layerGround);
        Debug.DrawRay(Limit.position, Vector2.right, Color.green);
        if (hit.collider)
        {
            Debug.Log(hit.transform.gameObject.name);
            if (movingRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }

    public bool isMovingRight()
    {

        return movingRight;
    }

}

  

