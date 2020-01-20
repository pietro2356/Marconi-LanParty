using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLComunicazione;
using System;
using System.Net;

public class GestoreComunicazione : MonoBehaviour
{
    ConnPermanenteSync connessione;
    int[] sceneiniziali = { 1 };
    int livello = 0;

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

        if (argomenti[3] == "true")
        {
            ChiamaRiconnessione();
        }
        else
        {
            IniziaConnessione();

            CambiaLivello(1);
        }
    }

    void IniziaConnessione()
    {
        connessione.MessaggioTx("CONTROLLOCOMUNICAZIONE$");
        for (byte i = 0; i < 1;)
        {
            string mess = connessione.Ricezione();
            if (mess == "INIZIO$")
            {
                Debug.Log("inizio");
                //Gestiore_Gioco.CambiaScena(1);
                i++;
            }
        }
    }

    void CambiaLivello(int livello)
    {
        connessione.MessaggioTx("FINELIVELLO$");
        this.livello = livello;
        for (byte i = 0; i < 1;)
        {
            string mess = connessione.Ricezione();
            if (mess == "INIZIOLIVELLO$")
            {
                Debug.Log("cambioSCena");
                Gestore_Gioco.CambiaScena(livello);
                i++;
            }
        }
    }

    public string PrendiDialogo(int riga)
    {
        switch (livello)
        {
            case 1:
                return DialoghiLivello1.dialoghi[riga];
            default:
                return "";
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

    private void ChiamaRiconnessione()
    {
        connessione.MessaggioTx("RICONNESSIONE$");
        for (byte i = 0; i < 1;)
        {
            string[] mess = connessione.Ricezione().Split('$');
            if (mess[0] == "RICONNESSO")
            {
                CambiaLivello(Convert.ToInt32(mess[2]) + 1);
                i++;
            }
        }
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Gestiore_Gioco.CambiaScena(1);
        //}

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

public class Domanda
{
    string testo;
    string risposta1;
    string risposta2;
    string risposta3;
    string risposta4;

    public string Testo { get => testo; set => testo = value; }
    public string Risposta1 { get => risposta1; set => risposta1 = value; }
    public string Risposta2 { get => risposta2; set => risposta2 = value; }
    public string Risposta3 { get => risposta3; set => risposta3 = value; }
    public string Risposta4 { get => risposta4; set => risposta4 = value; }

    public Domanda(string testo, string risposta1, string risposta2, string risposta3, string risposta4)
    {
        Testo = testo;
        Risposta1 = risposta1;
        Risposta2 = risposta2;
        Risposta3 = risposta3;
        Risposta4 = risposta4;
    }
}
