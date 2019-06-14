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

    // Start is called before the first frame update
    void Start()
    {
        posNueva = transform.position.y;
        comparandoFlow = false;
    }

    // Update is called once per frame
    void Update()
    {
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
                Debug.Log("ZASKO MASTER LAVA PA QUE TUS OIDOS GOCEN");
            }
        }

     }

        if (comparandoFlow)
        {
            posAntigua = transform.position.y;

            if (realTime >= 3)
            {
                posNueva = transform.position.y;
                comparandoFlow = false;
                realTime = 0;

            }


        }

        if (posA >= 6)
        {
            Debug.Log("COCINANDO SKILLS");
            //meter camera shake HERE
        }

        posA = posNueva - posAntigua;

    }
}
