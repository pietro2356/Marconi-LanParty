﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Gestore_File : MonoBehaviour
{
    string[] file = new string[] { "Protagonista;Prova", "Protagonista;Prova2" };
    public Dialogo PrendiDialogo(int riga)
    {
        string[] singolaRiga = file[riga].Split(';');
        return new Dialogo(singolaRiga[0], singolaRiga[1]);
    }

    public Domanda PrendiDomanda(int numDomanda)
    {
        return new Domanda("prova", "prova1", "prova2", "prova3", "prova4"); 
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

public class Dialogo
{
    string personaggio;
    string discorso;

    public string Personaggio { get => personaggio; set => personaggio = value; }
    public string Discorso { get => discorso; set => discorso = value; }

    public Dialogo(string personaggio, string discorso)
    {
        Personaggio = personaggio;
        Discorso = discorso;
    }
}