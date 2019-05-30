using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QSettingsScripts : MonoBehaviour
{
    public Text textoCalidad;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        textoCalidad = GameObject.Find("TextoCalidad").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (slider.value == 0)
        {
            textoCalidad.text = "BAJO".ToString();
            QualitySettings.SetQualityLevel(0);
        }
        if (slider.value == 1)
        {
            textoCalidad.text = "MEDIO".ToString();
            QualitySettings.SetQualityLevel(1);
        }
        if (slider.value == 2)
        {
            textoCalidad.text = "ALTA".ToString();
            QualitySettings.SetQualityLevel(2);
        }

        if (slider.value == 3)
        {
            textoCalidad.text = "ULTRA".ToString();
            QualitySettings.SetQualityLevel(3);
        }
    }
}
