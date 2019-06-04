using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startPanel;
    public static bool gameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
       gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void MenuPrincipal()
    { 
        SceneManager.LoadScene("Level 0");
    }

}
