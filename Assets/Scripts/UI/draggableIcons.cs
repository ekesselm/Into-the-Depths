using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggableIcons : MonoBehaviour
{
    public Texture2D iconoEnemigo;
    public Transform originalPos;

    public GameObject prefabEnemigo;

    public Transform mapaPos;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private Vector3 point;
    public mapDetection mapa;

    private Camera cam;

    public bool isPrefab;

    public controlUIButtons scriptButtons;


    void Start()
    {
        if (gameObject.name.Contains("(Clone)")) {
            isPrefab = true;
        } else
        {
            isPrefab = false;
        }

        cam = Camera.main;
    }
    public void OnMouseOver()
    {
    }

    public void OnMouseDown()
    {
        scriptButtons.tickSound.Play();

        //El icono seleccionado se vuelve el cursor hasta que lo sueltes
        if (isPrefab == false){

        Cursor.SetCursor(iconoEnemigo, hotSpot, cursorMode);

        }
    }

    void OnGUI()
    {

        point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

    }   
    void OnMouseUp()
    {
        scriptButtons.tickSound.Play();

        if (isPrefab == false)
        {
            //Si entra en el mapa, instancia en posición donde se arrastre.

            Cursor.SetCursor(null, Vector2.zero, cursorMode);

        if (mapa.iconInMap)
        {
            gameObject.transform.SetParent(mapaPos);
            Instantiate(prefabEnemigo, point, Quaternion.identity, transform.parent);

        } else if (isPrefab)
        {
           // Destroy(gameObject);
        }
        }
    }

    public void Destroy()
    {
        scriptButtons.sonidoRegresar.Play();

        if (isPrefab)
        {
            Destroy(gameObject);
        }
    }
}
