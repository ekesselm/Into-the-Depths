using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCrash : MonoBehaviour
{
    public float posAntigua;
    public float posNueva;

    public float realTime;
    public float maxTime = 0.2f;

    public float posA;

    public bool comparandoFlow;

    public CameraShake shakeScript;

    public bool isStarting;

    public AudioSource LandSound;

    public float temporizador;
    public bool SonidoSuelo;


    // Start is called before the first frame update
    void Start()
    {
        isStarting = false;
        StartCoroutine("RetardoShake");
        posNueva = transform.position.y;
        comparandoFlow = false;
    }

    IEnumerator RetardoShake()
    {
        yield return new WaitForSecondsRealtime(2f);
        isStarting = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (SonidoSuelo == true)
        {
            temporizador += 1 * Time.deltaTime;
        } else
        {
            temporizador = 0;
        }

        realTime += Time.deltaTime;

        if (comparandoFlow == false) { 

        if (realTime >= maxTime)
        {
            realTime = 0;
            posAntigua = posNueva;
            posNueva = transform.position.y;
            
            if (posAntigua > posNueva)
            {
                comparandoFlow = true;
            }
        }

     }

        if (comparandoFlow)
        {
            posAntigua = transform.position.y;

            if (realTime >= 1)
            {
                posNueva = transform.position.y;
                comparandoFlow = false;
                realTime = 0;
             
            }

            posA = posNueva - posAntigua;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SonidoSuelo = false;

        if (temporizador >= 0.3)
        {
            LandSound.Play();
        }

        if (posA >= 7 && isStarting)
        {
            shakeScript.ShakeElapsedTime = shakeScript.ShakeDuration;
        }

        posA = 0;
        comparandoFlow = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        SonidoSuelo = true;

    }
}
