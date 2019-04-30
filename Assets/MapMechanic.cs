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

    public const string DRAGGABLE_TAG = "UIDraggable";
    private bool dragging = false;

    private Vector2 originalPosition;

    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();

    // Start is called before the first frame update
    void Start()
    {
        PanelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
    
      if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;

                objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;

            }
        
        if (dragging)
            {
                objectToDrag.position = Input.mousePosition;
            }

        }
      if (Input.GetKeyDown(KeyCode.Space))
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

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0) return null;

        return hitObjects[0].gameObject;
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject clickedObject = GetObjectUnderMouse();

        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }
}
