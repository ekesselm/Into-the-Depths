using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    public int Life = 4;
    private Animator animator;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;

    public float x;
    public float y;
    public float z;

    Scene escenaActual;

    public GameObject player;

    private float time = 0.0f;
    public float waitTime = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();
        escenaActual = SceneManager.GetActiveScene();
        LoadData();
        InvokeRepeating("LastRespawn", 5f, waitTime);

    }

    /*IEnumerator SaveRespawn()
    {
        Debug.Log("Start waiting: " + Time.realtimeSinceStartup);

        if (waitForSecondsRealtime == null)
            waitForSecondsRealtime = new WaitForSecondsRealtime(waitTime);
        else
            waitForSecondsRealtime.waitTime = waitTime;
        yield return waitForSecondsRealtime;

        Debug.Log("End waiting: " + Time.realtimeSinceStartup);
    }
    
    //si pasa waitTime, el contador se resetea y se ejecuta LastRespawn...

    IEnumerator tiempoRespawneo()
    {
        print(Time.time);
        yield return new WaitForSeconds(waitTime);
        LastRespawn();
        print(Time.time);
    }*/

    void Update()
    {
        /*time += Time.deltaTime;
        //se ejecuta la corrutina 

        if ( Time.time > waitTime)
        {
            StartCoroutine(tiempoRespawneo());
        }*/

        if (Life == 4)
        {
           c4.SetActive(true);
           c3.SetActive(true);
           c2.SetActive(true);
           c1.SetActive(true);
        } 

        if (Life == 3)
        {
            c4.SetActive(false);
            c3.SetActive(true);
            c2.SetActive(true);
            c1.SetActive(true);
        }


        if (Life == 2)
        {
            c4.SetActive(false);
            c3.SetActive(false);
            c2.SetActive(true);
            c1.SetActive(true);
        }


        if (Life == 1)
        {
            c4.SetActive(false);
            c3.SetActive(false);
            c2.SetActive(false);
            c1.SetActive(true);
            animator.SetBool("lowHealth", true);
        }


        if (Life <= 0)
        {

            SceneManager.LoadScene(escenaActual.name);

        }
    }

    void LastRespawn()
    {
        Debug.Log("RespawnSaved");
        PlayerPrefs.SetFloat("posX", transform.position.x);
        PlayerPrefs.SetFloat("posY", transform.position.y);
        PlayerPrefs.Save();
    }

    void LoadData()
    {
        Vector3 position = Vector3.zero;

        position.x = PlayerPrefs.GetFloat("posX");
        position.y = PlayerPrefs.GetFloat("posY");

        player.transform.position = position;


        /*position.x = PlayerPrefs.GetFloat("posX");
        position.y = PlayerPrefs.GetFloat("posY");*/

    }

}
