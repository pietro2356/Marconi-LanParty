using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvvioDebug : MonoBehaviour
{
    GestoreComunicazione gestore;

    private void Start()
    {
        gestore = GameObject.FindGameObjectsWithTag("GestoreGioco")[0].GetComponent<GestoreComunicazione>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gestore.CambiaLivelloSoloDebug(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gestore.CambiaLivelloSoloDebug(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gestore.CambiaLivelloSoloDebug(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gestore.CambiaLivelloSoloDebug(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gestore.CambiaLivelloSoloDebug(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            gestore.CambiaLivelloSoloDebug(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            gestore.CambiaLivelloSoloDebug(7);
        }
    }
}
