using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectionArea : MonoBehaviour
{
    public EnemyGroundMovement enemyMovevement;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enemyMovevement.TurnTowardsPlayer(collision.gameObject);
        }
    }

}
