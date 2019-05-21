using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundScript : MonoBehaviour
{
    public GameObject LookAroundObject;
    public float speed = 10f;
    private Vector2 positionTarget;
    public Camera gameCamera;

    private void Start()
    {
        // Necesario para usar el OnMouseOver en un trigger
        Physics.queriesHitTriggers = true;
    }

    private void Update()
    {
    }

    private void OnMouseOver()
    {
        // Nueva posición objetivo

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = new Vector2(mousePosition.x, mousePosition.y);
        LookAroundObject.transform.position = mousePosition;

        Debug.Log("Input.mousePosition " + Input.mousePosition);
        Debug.Log("Nueva posición " + mousePosition);


        // Mientras el ratón esé en el area, el objeto vacío se mueve hacia la pos del ratón
        //Debug.Log("LookAroundObject " + LookAroundObject.transform.position);
    }
    


}
