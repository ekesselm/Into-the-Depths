using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlUIButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NuevaPartida()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Opciones()
    {

    }

    public void CerrarPartida()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
