using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class audioVolumen : MonoBehaviour
{
    public Slider slider;
    public const string volumen = "volumen";
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("volumen"))
        {

            AudioListener.volume = PlayerPrefs.GetFloat("volumen");

            if (slider != null) {
                slider.value = PlayerPrefs.GetFloat("volumen") * 10;
            }
        }

        else
        {
            slider.value = 10;
            AudioListener.volume = 1f;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("volumen"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("volumen");;
        }
        if (slider != null)
        {
            if (slider.value == 0)
            {
                PlayerPrefs.SetFloat("volumen", 0f);
                PlayerPrefs.Save();
            }
            if (slider.value == 1)
            {
                PlayerPrefs.SetFloat("volumen", 0.1f);
                PlayerPrefs.Save();
            }
            if (slider.value == 2)
            {

                PlayerPrefs.SetFloat("volumen", 0.2f);
                PlayerPrefs.Save();
            }
            if (slider.value == 3)
            {
                PlayerPrefs.SetFloat("volumen", 0.3f);
                PlayerPrefs.Save();
            }
            if (slider.value == 4)
            {
                PlayerPrefs.SetFloat("volumen", 0.4f);
                PlayerPrefs.Save();
            }
            if (slider.value == 0.5)
            {
                PlayerPrefs.SetFloat("volumen", 0.5f);
                PlayerPrefs.Save();
            }
            if (slider.value == 6)
            {
                PlayerPrefs.SetFloat("volumen", 0.6f);
                PlayerPrefs.Save();
            }
            if (slider.value == 7)
            {
                PlayerPrefs.SetFloat("volumen", 0.7f);
                PlayerPrefs.Save();
            }
            if (slider.value == 8)
            {
                PlayerPrefs.SetFloat("volumen", 0.8f);
                PlayerPrefs.Save();
            }
            if (slider.value == 9)
            {
                PlayerPrefs.SetFloat("volumen", 0.9f);
                PlayerPrefs.Save();
            }
            if (slider.value == 10)
            {

                PlayerPrefs.SetFloat("volumen", 1f);
                PlayerPrefs.Save();
            }

        }
    }
}
