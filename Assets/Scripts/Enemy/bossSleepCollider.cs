using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSleepCollider : MonoBehaviour
{
    public BossScript scriptdelBoss;
    public AudioSource musicaBoss;
    public AudioSource musicaBG;

    private void Update()
    {
        if (scriptdelBoss.sleep)
        {
            scriptdelBoss.bossRB.bodyType = RigidbodyType2D.Static;
            scriptdelBoss.col1.enabled = false;
            scriptdelBoss.col2.enabled = false;
            scriptdelBoss.colDormido.enabled = true;
        }
        else
        {

            scriptdelBoss.bossRB.bodyType = RigidbodyType2D.Kinematic;
            scriptdelBoss.col1.enabled = true;
            scriptdelBoss.col2.enabled = true;
            scriptdelBoss.colDormido.enabled = false;
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        //Para que, cuando choque con el player, se despierte. 

        if (Input.GetKey(KeyCode.Q))
        {
            musicaBoss.Play();
            musicaBG.Stop();
            scriptdelBoss.sleep = false;
            scriptdelBoss.GetComponent<Animator>().SetBool("sleep", false);

        }

    }
}
