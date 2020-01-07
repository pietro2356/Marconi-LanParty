using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gestore_File : MonoBehaviour
{
    public string PrendiDialogo(int riga)
    {
        string singolaRiga = DialoghiLivello1.dialoghi[riga];
        return singolaRiga;
    }

    public Domanda PrendiDomanda(int numDomanda)
    {
        string[] singolaRiga = DialoghiLivello1.dialoghi[numDomanda].Split(';');
        return new Domanda(singolaRiga[0], singolaRiga[1], singolaRiga[2], singolaRiga[3], singolaRiga[4]); 
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

