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

    void Start()
    {
        cam = Camera.main;
    }
    public void OnMouseOver()
    {
        
    }

    public void OnMouseDown()
    {
        //El icono seleccionado se vuelve el cursor hasta que lo sueltes
        Cursor.SetCursor(iconoEnemigo, hotSpot, cursorMode);
        Debug.Log("auauauauau");
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

    // Update is called once per frame
    void Update()
    {

    }
}
