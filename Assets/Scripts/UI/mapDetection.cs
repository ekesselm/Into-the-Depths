using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapDetection : MonoBehaviour
{
    public bool iconInMap;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnMouseEnter()
    {
        iconInMap = true;
    }

    public void OnMouseExit()
    {
        iconInMap = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
