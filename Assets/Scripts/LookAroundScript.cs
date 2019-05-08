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
        Physics.queriesHitTriggers = true;
        positionTarget = LookAroundObject.transform.position;
    }

    private void Update()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;

    }

    private void OnMouseOver()
    {
        positionTarget = camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Nueva posición " + positionTarget);
        LookAroundObject.transform.position = Vector2.MoveTowards(LookAroundObject.transform.position, positionTarget, Time.deltaTime * speed);
        Debug.Log("LookAroundObject " + LookAroundObject.transform.position);
    }
    


}
