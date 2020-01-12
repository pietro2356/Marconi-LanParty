using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLComunicazione;
using System;

public class GestoreComunicazione : MonoBehaviour
{
    ConnPermanente connessione;

    // Start is called before the first frame update
    void Start()
    {
        connessione = new ConnPermanente("127.0.0.1", 36107);
        connessione.MessaggioRicevuto += GestoreMessaggi;
    }

    private void GestoreMessaggi(object sender, EventArgs e)
    {
        switch (connessione.MessaggioRx)
        {
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Gestiore_Gioco.CambiaScena(1);
        }
    }
}
