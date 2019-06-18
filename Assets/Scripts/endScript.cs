using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScript : MonoBehaviour
{
    public GameObject boss;
    public GameObject panelEnd;

    // Start is called before the first frame update
    void Start()
    {
        panelEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            panelEnd.SetActive(true);
        } 

    }
}
