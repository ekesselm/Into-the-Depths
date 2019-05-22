using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlUIButtons : MonoBehaviour
{
    public Animator fade;
    public GameObject FadePanel;

    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("FadePanel").GetComponent<Animator>();
        //fade = GetComponent<Animator>();
        FadePanel.SetActive(false);
    }

    public void NuevaPartida()
    {
        SceneManager.LoadScene("Level 1");
    }

    

    public void Fade()
    {
        FadePanel.SetActive(true);
        fade.SetBool("FadingTime", true);
        StartCoroutine("EsperaQueFade");
    }

    public void CerrarPartida()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    IEnumerator EsperaQueFade()
    {
      
        yield return new WaitForSeconds(0.4f);
        fade.SetBool("FadingTime", false);
        FadePanel.SetActive(false);

    }
    
    // Update is called once per frame
    void Update()
    {
       if (fade == null)
        {
            fade = GameObject.Find("FadePanel").GetComponent<Animator>();
        }
    }
}
