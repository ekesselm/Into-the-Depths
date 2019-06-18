using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlUIButtons : MonoBehaviour
{
    public Animator fade;
    public GameObject FadePanel;

    public AudioSource cambiarOpcionSound;
    public AudioSource tickSound;
    public AudioSource sonidoRegresar;

    public GameObject bgParticles;

    public Scene scene;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
    }

    public void sonidoCambiarOpcion()
    {
        cambiarOpcionSound.Play();
    }

    public void tickSonidoSound()
    {
        tickSound.Play();
    }

    public void playSonidoRegresar()
    {
        sonidoRegresar.Play();
    }


    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menus");
    }

    public void NuevaPartida()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level 1");

    }

    public void Fade()
    {
        bgParticles.SetActive(false);
        FadePanel.SetActive(true);
        fade.SetBool("FadingTime", true);
        StartCoroutine("EsperaQueFade");
    }

    public void CerrarPartida()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    IEnumerator EsperaQueFade()
    {
      
        yield return new WaitForSeconds(0.4f);
        fade.SetBool("FadingTime", false);
        FadePanel.SetActive(false);
        bgParticles.SetActive(true);

    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cambiarOpcionSound.Play();
        }

        if (fade == null && scene.name.Equals("Menus"))
        {
            fade = GameObject.Find("FadePanel").GetComponent<Animator>();
        }
    }
}
