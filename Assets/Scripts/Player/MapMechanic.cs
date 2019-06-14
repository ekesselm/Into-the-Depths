using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapMechanic : MonoBehaviour
{
    public GameObject vida;
    public GameObject panel;
    public bool PanelActive;

    // Start is called before the first frame update
    void Start()
    {
        PanelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
    
      if (Input.GetKeyDown(KeyCode.M))
        {
            PanelActive = !PanelActive;
        } 

      if (PanelActive == true )
        {
            panel.SetActive(true);

        } else
        {
            panel.SetActive(false);
        }
    }

}
