using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalZoneDetectionScript : MonoBehaviour
{
    public BoxCollider2D colliderZonaFinal;
    public bool EnteringZonaFinal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.transform.tag == "Player")
        {
            EnteringZonaFinal = true;
            Debug.Log("Entra");
        }
    }
}
