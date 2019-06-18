using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemyPD : MonoBehaviour
{
    public AirEnemy scriptEnemyAire;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.transform.CompareTag("Player") && scriptEnemyAire.Attacking)
        {
            scriptEnemyAire.GiraGira = false;
            scriptEnemyAire.StartCoroutine("CooldownAtaque");
            scriptEnemyAire.StartCoroutine("CooldownDos");
            scriptEnemyAire.AttackCheck = true;
            scriptEnemyAire.Enemy2Attack.Play();
            scriptEnemyAire.Enemy2Anim.SetBool("playerAround", true);
            scriptEnemyAire.Enemy2Attack.Play();
            scriptEnemyAire.playerPos = scriptEnemyAire.player.transform.position;
            scriptEnemyAire.target = scriptEnemyAire.playerPos;

            if (transform.position.x < scriptEnemyAire.player.transform.position.x && scriptEnemyAire.target == scriptEnemyAire.playerPos)
            {
                scriptEnemyAire.spriteRen.flipX = true;
            }
            else
            {
                scriptEnemyAire.spriteRen.flipX = false;
            }


        }
    }
}
