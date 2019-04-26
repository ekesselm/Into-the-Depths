using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyGroundAttack))]
public class EnemyGroundMovement : MonoBehaviour
{

    public Transform Limit;
    public float speed;

    public bool isAttacking = false;
    public bool isStopped = false;

    private bool movingRight = true;

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
    }

    public bool isMovingRight()
    {

        return movingRight;
    }

}

  

