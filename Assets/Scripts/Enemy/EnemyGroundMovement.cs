using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyGroundAttack))]
public class EnemyGroundMovement : MonoBehaviour
{

    public Transform Limit;
    public float speed;
    public float distance;
    public Collider2D playerDetectionArea;

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
                RotateLeft();
            }
            else
            {
                RotateRight();
            }
        }
        
        RaycastHit2D hit = Physics2D.Raycast(Limit.position, Vector2.right, 0.6f, layerGround);
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

    private void RotateRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        movingRight = true;
    }

    private void RotateLeft()
    {
        transform.eulerAngles = new Vector3(0, -180, 0);
        movingRight = false;
    }

    public void TurnTowardsPlayer(GameObject player)
    {
        if (transform.position.x > player.transform.position.x) // El player está a la IZQUIERDA
        {
            Debug.Log("Girar a la izquierda");
            RotateLeft();
        }
        else // El player está a la DERECHA
        {
            Debug.Log("Girar a la derecha");
            RotateRight();
        }
    }

}

  

