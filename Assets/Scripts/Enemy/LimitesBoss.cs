using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesBoss : MonoBehaviour
{
    public BossScript scriptDelBoss;
    public bool derecha;

    // Start is called before the first frame update
    void Start()
    {
        scriptDelBoss = GameObject.Find("Boss").GetComponent<BossScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)


    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("ENTEEEEEEEEEEEER");
            if (derecha)
        {
            scriptDelBoss.movimientoDer = true;
            scriptDelBoss.movimientoIzq = false;

        } else
        {
            scriptDelBoss.movimientoDer = false;
            scriptDelBoss.movimientoIzq = true;
        }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            scriptDelBoss.movimientoDer = false;
            scriptDelBoss.movimientoIzq = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
