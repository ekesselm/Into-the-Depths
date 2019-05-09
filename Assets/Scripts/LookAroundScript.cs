using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundScript : MonoBehaviour
{
    public GameObject LookAroundObject;
    public float speed = 10f;
    private Vector2 positionTarget;
    public Camera camera;

    private void Start()
    {
        // Necesario para usar el OnMouseOver en un trigger
        Physics.queriesHitTriggers = true;

        // Target inicial de la cámara: La posición por defecto del personaje
        positionTarget = LookAroundObject.transform.position;
    }

    private void Update()
    {
        // El objeto vacío sigue al jugador (ya que no puede ser hijo de este)
        LookAroundObject.transform.position = Vector2.MoveTowards(LookAroundObject.transform.position, positionTarget, Time.deltaTime * speed);
            ;
    }

    private void OnMouseOver()
    {
        // Nueva posición objetivo

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = new Vector3(mousePosition.x, mousePosition.y, 1.0f);
        positionTarget = camera.ScreenToWorldPoint(mousePosition);
        Debug.Log("Nueva posición " + positionTarget);


        // Mientras el ratón esé en el area, el objeto vacío se mueve hacia la pos del ratón
        //Debug.Log("LookAroundObject " + LookAroundObject.transform.position);
    }
    


}
