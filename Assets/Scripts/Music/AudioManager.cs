using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource BGsounds;
    public AudioClip sonidoExterior;
    public AudioClip sonidoInterior;

    public AudioClip ITDThemeP2;

    public bool isPlaying;

    public Animator musicAnim;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            BGsounds.Play();
            isPlaying = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "DetectorZonaMusica" && BGsounds.clip.name != sonidoInterior.name)
        {
            isPlaying = true;
            BGsounds.clip = sonidoInterior;
            musicAnim.SetTrigger("FadeIn");

            if (BGsounds.clip.name == "mainTheme3")
            {
                sonidoExterior = ITDThemeP2;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "DetectorZonaMusica" && BGsounds.clip.name != sonidoExterior.name)
        {

            isPlaying = true;
            musicAnim.SetTrigger("FadeOut");
            BGsounds.clip = sonidoExterior;

        }
    }
}

