using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectionArea : MonoBehaviour
{
    public BossScript scriptDelBoss;
    private bool awake;

    private void Start()
    {
        awake = scriptDelBoss.awake;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (awake){

            if (collision.transform.CompareTag("Player"))
            {
             scriptDelBoss.TurnTowardsPlayer(collision.gameObject);
            }
        }
    }
}
