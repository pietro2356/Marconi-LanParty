using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CLComunicazione;
using System;
using System.Net;
using UnityEngine.SceneManagement;

public class GestoreComunicazione : MonoBehaviour
{
    ConnPermanenteSync connessione;
    int[] sceneiniziali = { 1, 2, 6 };
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

            //CambiaLivello(1);
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

    public void CambiaLivello(int livello)
    {
        connessione.MessaggioTx("FINELIVELLO$");
        this.livello = livello;
        for (byte i = 0; i < 1;)
        {
            string mess = connessione.Ricezione();
            if (mess == "INIZIOLIVELLO$")
            {
                Debug.Log("cambioSCena");
                CambiaScenaDaLivello(livello);
                i++;
            }
        }
    }

    public void CambiaLivelloSoloDebug(int nlivelli)
    {
        livello = nlivelli;
        for (byte i = 0; i < nlivelli; i++)
        {
            connessione.MessaggioTx("FINELIVELLO$");
            
            for (byte j = 0; j < 1;)
            {
                string mess = connessione.Ricezione();
                if (mess == "INIZIOLIVELLO$")
                {
                    j++;
                }
            }
        }
        Debug.Log("AvvioLivello " + livello);
        CambiaScenaDaLivello(livello);
    }

    public string PrendiDialogo(int riga)
    {
        switch (livello)
        {
            case 0:
                return DialoghiLivello0.dialoghi[riga];
            case 1:
                return DialoghiLivello1.dialoghi[riga];
            case 2:
                return DialoghiLivello2.dialoghi[riga];
            default:
                return ";";
        }
        
    }

    public Domanda RichiediDomanda()
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

    public int RispostaDomanda(int numeroRisposta)
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

    public void FineMinigioco(int punteggio)
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

    public void CambiaScenaDaLivello(int nlivello)
    {
        SceneManager.LoadScene(sceneiniziali[nlivello]);
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
