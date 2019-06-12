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

    public Image whiteScreen;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;

    private float x;
    private float y;
    private float z;

    Scene escenaActual;

    public GameObject player;

    private float time = 0.0f;
    public float waitTime = 10f;

    void Start()
    {
        player.transform.position = new Vector3(0, -85, 0);
        whiteScreen.canvasRenderer.SetAlpha(1.0f);
        FadeOut();
        LoadData();
        animator = GetComponent<Animator>();
        escenaActual = SceneManager.GetActiveScene();
        InvokeRepeating("LastRespawn", 5f, waitTime);

    }

    public void FadeIn()
    {
        whiteScreen.CrossFadeAlpha(1.0f, 2.0f, true);
    }

    public void FadeOut()
    {
        whiteScreen.CrossFadeAlpha(0.0f, 2.0f, true);
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
    }*/

    //si pasa waitTime, el contador se resetea y se ejecuta LastRespawn...

    IEnumerator GameOver()
    {
        animator.SetBool("muerte", true);
        yield return new WaitForSecondsRealtime(0.2f);
        Time.timeScale = 0;
        FadeIn();
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(escenaActual.name);
        Time.timeScale = 1;

    }

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


        if (Life == 0)
        {
            c4.SetActive(false);
            c3.SetActive(false);
            c2.SetActive(false);
            c1.SetActive(false);
            StartCoroutine(GameOver()); 

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
