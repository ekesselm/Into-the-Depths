using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundScript : MonoBehaviour
{
    public GameObject LookAroundObject;
    public GameObject player;
    //public Cinemachine.CinemachineVirtualCameraBase CMcamera;

    private Movement playerMovement;

    public MapMechanic scriptMapa;
    private Vector2 positionTarget;

    private void Start()
    {
        // Necesario para usar el OnMouseOver en un trigger
        Physics.queriesHitTriggers = true;

        playerMovement = player.GetComponent<Movement>();
    }

    private void Update()
    {
        if (scriptMapa.PanelActive == false) { 

        if (playerMovement.IsMoving()) LookAroundObject.transform.position = player.transform.position;
        transform.position = player.transform.position;

        }
    }

    private void OnMouseOver()
    {
        if (scriptMapa.PanelActive == false) { 
        if (!playerMovement.IsMoving())

        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane);
            LookAroundObject.transform.position = mousePosition;

            }
        }
    }
}
