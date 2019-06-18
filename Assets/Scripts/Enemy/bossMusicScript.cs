using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossMusicScript : MonoBehaviour
{

    public EnemyHealth bossHealthScript;
    public AudioSource sonidoRespiracion;


    void Start()
    {
        
    }

    public void gruñidoRespirar()
    {
        sonidoRespiracion.Play();
    }


    void Update()
    {
        if (bossHealthScript.enemyLife == 0)
        {
            sonidoRespiracion.Stop();
        }
    }
}
