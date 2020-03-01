﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//public class GestioneGriglia_Colori : MonoBehaviour
//{
//    const byte DIM_X = 11, DIM_Y = 6;

//    SpriteRenderer g_renderer;
//    Transform g_transform;

//    [NonSerialized]
//    public Vector2 dimCella;

//    public Linea_Colori[,] griglia = new Linea_Colori[DIM_X, DIM_Y];

//    static List<InfoCelle_colori> celleGriglia;

//    public List<GameObject> pezzi = new List<GameObject>();

//    public static List<InfoCelle_colori> CelleGriglia
//    {
//        get { return celleGriglia; }
//        set { celleGriglia = value; }
//    }

//    public static GestioneGriglia_Colori istanza;

//    public GameObject pannelloIntermedio;
//    public GameObject pannelloFine;

//    [NonSerialized]
//    public bool giocoAttivo;

//    System.Random random = new System.Random();

//    byte modelloUsato;

//    public GameObject timer;

//    byte schema = 0;

//    void Awake()
//    {
//        g_renderer = GetComponent<SpriteRenderer>();
//        g_transform = transform;

//        celleGriglia = new List<InfoCelle_colori>();

//        SetupGriglia();

//        istanza = this;

//        inizio();
//    }

//    private void OnMouseDown()
//    {
//        Vector3 posizione = Input.mousePosition;

//        //calcolo cella
//        //pezzi[0].GetComponent<SpriteRenderer>().color = Color.black;

//    }

//    void inizio()
//    {
//        modelloUsato = (byte)random.Next(1, Modelli.modelli.Length);

//        GeneraPezzi(Modelli.modelli[modelloUsato].Schema);

//        giocoAttivo = true;

//        timer.GetComponent<Gestore_Timer>().avviaTimer();
//    }

//    void SetupGriglia()
//    {
//        celleGriglia.Clear();
//        foreach (var pezzo in griglia)
//        {
//            if (pezzo != null)
//            {
//                Destroy(pezzo.linea);
//            }
//        }
//        griglia = new Linea_Colori[DIM_X, DIM_Y];

//        Vector3 dimScacchiera = g_renderer.size;

//        Vector2 dimCella = new Vector2((dimScacchiera.x - 0.06f) / DIM_X, (dimScacchiera.y - 0.06f) / DIM_Y);

//        this.dimCella = dimCella;

//        Vector3 posStart = new Vector3((g_transform.position.x - ((dimScacchiera.x - 0.06f) / 2)) + (dimCella.x / 2), (g_transform.position.y - ((dimScacchiera.y - 0.06f) / 2)) + (dimCella.y / 2));

//        for (int i = 0; i < DIM_X; i++)
//        {
//            for (int j = 0; j < DIM_Y; j++)
//            {
//                byte orizzontale = (byte)i;
//                byte verticale = (byte)j;
//                Vector3 posCella = new Vector3(posStart.x + (dimCella.x * i), posStart.y + (dimCella.y * j));

//                InfoCelle_colori cella = new InfoCelle_colori(orizzontale, verticale, posCella);

//                CelleGriglia.Add(cella);
//            }
//        }
//    }

//    void GeneraPezzi(byte[,] disposizione)
//    {
//        foreach (var cella in celleGriglia)
//        {
//            Destroy(cella.pezzoInterno);
//            cella.pezzoInterno = null;
//            cella.pezzoInterno = null;
//        }

//        for (int x = 0; x < DIM_X; x++)
//        {
//            for (int y = 0; y < DIM_Y; y++)
//            {
//                if (disposizione[x, y] != 0)
//                {
//                    InfoCelle cellaDaTrovare = GetInfoCelle((byte)x, (byte)y);
//                    Vector3 puntoSpawn = cellaDaTrovare.posCella;

//                    GameObject pezzo = Instantiate(pezzi[disposizione[x, y]], new Vector3(puntoSpawn.x, puntoSpawn.y, g_transform.position.z - 1), Quaternion.identity);

//                    griglia[x, y] = new Tubi(x, y, 0, (tipoPezzo)disposizione[x, y], pezzo);
//                    pezzo.GetComponent<Gestore_pezzo>().questo = griglia[x, y];

//                    byte rotazioni = (byte)random.Next(0, 4);
//                    for (int i = 0; i < rotazioni; i++)
//                    {
//                        pezzo.GetComponent<Gestore_pezzo>().Ruota(); ;
//                    }

//                    cellaDaTrovare.pezzoInterno = pezzo;

//                    cellaDaTrovare.tipoPezzo = (tipoPezzo)disposizione[x, y];
//                }

//            }
//        }
//    }

//    public static InfoCelle GetInfoCelle(byte x, byte y)
//    {
//        List<InfoCelle> Linea = celleGriglia.FindAll(a => a.coordinate.orizzontale == x);

//        InfoCelle cella = Linea.Find(b => b.coordinate.verticale == y);

//        return cella;
//    }

//    public void ControllaVincita()
//    {
//        if (controllaPercorso())
//        {
//            if (schema == 0)
//            {
//                pannelloIntermedio.SetActive(true);
//            }
//            else
//            {
//                pannelloFine.SetActive(true);
//            }
//            giocoAttivo = false;
//        }
//    }


//    public bool controllaPercorso()
//    {
//        for (int x = 0; x < DIM_X; x++)
//        {
//            for (int y = 0; y < DIM_Y; y++)
//            {
//                if (griglia[x, y] != null)
//                {
//                    if (Modelli.modelli[modelloUsato].Soluzione[x, y] == -1)
//                    {
//                    }
//                    else if (griglia[x, y].tipoTubo == tipoPezzo.dritto)
//                    {
//                        if (griglia[x, y].gradi != Modelli.modelli[modelloUsato].Soluzione[x, y] && griglia[x, y].gradi + 180 != Modelli.modelli[modelloUsato].Soluzione[x, y] && griglia[x, y].gradi - 180 != Modelli.modelli[modelloUsato].Soluzione[x, y])
//                        {
//                            return false;
//                        }
//                    }
//                    else if (griglia[x, y].tipoTubo == tipoPezzo.quatroUscite)
//                    {
//                    }
//                    else
//                    {
//                        if (griglia[x, y].gradi != Modelli.modelli[modelloUsato].Soluzione[x, y])
//                        {
//                            return false;
//                        }
//                    }
//                }
//            }
//        }
//        return true;
//    }

//    public void InizioIntermedio()
//    {
//        pannelloIntermedio.SetActive(false);
//        schema++;
//        inizio();
//    }
//}


//public class InfoCelle_colori
//{
//    public Coordinate_scacchiera coordinate;
//    public GameObject pezzoInterno;
//    public Vector3 posCella;
//    public tipoPezzo_Colori tipoPezzo;

//    public InfoCelle_colori(byte orizzontale, byte verticale, Vector3 pos, GameObject pezzo = null, tipoPezzo_Colori tipo = tipoPezzo_Colori.vuoto)
//    {
//        coordinate.orizzontale = orizzontale;
//        coordinate.verticale = verticale;
//        pezzoInterno = pezzo;
//        posCella = pos;
//        tipoPezzo = tipo;
//    }
//}
