using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLComunicazione;
using System;
using System.Net;

public class GestoreComunicazione : MonoBehaviour
{
    ConnPermanenteSync connessione;

    void Start()
    {
        string[] argomenti = Environment.GetCommandLineArgs();
        IPEndPoint server;
        try
        {
            server = new IPEndPoint(IPAddress.Parse(argomenti[1]), Convert.ToInt32(argomenti[2]));
        }
        catch (Exception)
        {
            server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 36108);
        }

        connessione = new ConnPermanenteSync(server);

        IniziaConnessione();

        CambiaLivello(0);

    }

    void IniziaConnessione()
    {
        connessione.MessaggioTx("CONTROLLOCOMUNICAZIONE$");
        for (byte i = 0; i < 1;)
        {
            string mess = connessione.Ricezione();
            if (mess == "INIZIO$")
            {
                Gestiore_Gioco.CambiaScena(1);
                i++;
            }
        }
    }

    void CambiaLivello(int nScena)
    {
        connessione.MessaggioTx("FINELIVELLO$");
        for (byte i = 0; i < 1;)
        {
            string mess = connessione.Ricezione();
            if (mess == "INIZIOLIVELLO$")
            {
                Debug.Log("cambioSCena");
                //Gestiore_Gioco.CambiaScena(nScena);
                i++;
            }
        }
    }

    Domanda RichiediDomanda()
    {
        connessione.MessaggioTx("DOMANDA$");
        for (byte i = 0; i < 1;)
        {
            string[] mess = connessione.Ricezione().Split('$');
            if (mess[0] == "DOMANDA")
            {
                return new Domanda(mess[1], mess[2], mess[3], mess[4], mess[5]);
            }
        }
        return null;
    }

    int RispostaDomanda(int numeroRisposta)
    {
        connessione.MessaggioTx("RISPOSTA$" + numeroRisposta);
        for (byte i = 0; i < 1;)
        {
            string[] mess = connessione.Ricezione().Split('$');
            if (mess[0] == "CONTROLLO")
            {
                return Convert.ToInt32(mess[1]);
            }
        }
        return 0;
    }

    void FineMinigioco(int punteggio)
    {
        connessione.MessaggioTx("FINEMINIGIOCO$" + punteggio);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Gestiore_Gioco.CambiaScena(1);
        }

        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    CambiaLivello(0);
        //}

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    Domanda buffer = RichiediDomanda();
        //    Debug.Log(buffer.Testo + "\n" + buffer.Risposta1 + "\n" + buffer.Risposta2 + "\n" + buffer.Risposta3 + "\n" + buffer.Risposta4);
        //}

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Debug.Log(RispostaDomanda(1));
        //}

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    FineMinigioco(50);
        //}
    }
}
