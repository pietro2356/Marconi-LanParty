﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GesgtioneGriglia : MonoBehaviour
{
    const byte DIM_X = 11, DIM_Y = 6;

    SpriteRenderer g_renderer;
    Transform g_transform;

    [NonSerialized]
    public Vector2 dimCella;

    public Tubi[,] griglia = new Tubi[11, 6];

    static List<InfoCelle> celleGriglia;

    public List<GameObject> pezzi = new List<GameObject>();
    List<GameObject> pezziGenerati = new List<GameObject>();

    public static List<InfoCelle> CelleGriglia
    {
        get { return celleGriglia; }
        set { celleGriglia = value; }
    }

    public static GesgtioneGriglia istanza;

    public GameObject pannelloFine;

    Quaternion[] orientamento = new Quaternion[] { new Quaternion(0, 0, 0, 1), new Quaternion(0, 0, 90, 1), new Quaternion(0, 0, 180, 1), new Quaternion(0, 0, 270, 1) };
    System.Random random = new System.Random();

    //LA MATRICE VA LETTA GIRATA DI 90° IN SENSO ANTI-ORARIO!
    /*byte[,] prova = new byte[,] {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } ,
        { 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
    };*/

    /* La matrice va girata di 90° in senso anti-orario!
     * O la si tiene così altrimenti bisogna creare un metodo per girarla.s
     */


    void Awake()
    {
        g_renderer = GetComponent<SpriteRenderer>();
        g_transform = transform;

        celleGriglia = new List<InfoCelle>();

        SetupGriglia();

        GeneraPezzi(Modelli.modello1.Schema);

        istanza = this;
    }

    #region NonServeAdUnCazzo
    void Test(int x, int y, byte[,] matrix)
    {
        InfoCelle cellaDaTrovare = GetInfoCelle((byte)x, (byte)y);
        Vector3 puntoSpawn = cellaDaTrovare.posCella;

        GameObject pezzo = Instantiate(pezzi[matrix[x, y]], new Vector3(puntoSpawn.x, puntoSpawn.y, g_transform.position.z - 1), Quaternion.identity);
        pezziGenerati.Add(pezzo);

        cellaDaTrovare.pezzoInterno = pezzo;

        cellaDaTrovare.tipoPezzo = (tipoPezzo)matrix[x, y];
    }
    # endregion NonServeAdUnCazzo

    void SetupGriglia()
    {
        celleGriglia.Clear();
        foreach (var pezzo in pezziGenerati)
        {
            Destroy(pezzo);
        }
        pezziGenerati.Clear();

        Vector3 dimScacchiera = g_renderer.size;

        Vector2 dimCella = new Vector2((dimScacchiera.x - 0.06f) / DIM_X, (dimScacchiera.y - 0.06f) / DIM_Y);

        this.dimCella = dimCella;

        Vector3 posStart = new Vector3((g_transform.position.x - ((dimScacchiera.x - 0.06f) / 2)) + (dimCella.x / 2), (g_transform.position.y - ((dimScacchiera.y - 0.06f) / 2)) + (dimCella.y / 2));

        for (int i = 0; i < DIM_X; i++)
        {
            for (int j = 0; j < DIM_Y; j++)
            {
                byte orizzontale = (byte)i;
                byte verticale = (byte)j;
                Vector3 posCella = new Vector3(posStart.x + (dimCella.x * i), posStart.y + (dimCella.y * j));

                InfoCelle cella = new InfoCelle(orizzontale, verticale, posCella);

                CelleGriglia.Add(cella);
            }
        }
    }

    void GeneraPezzi(byte[,] disposizione)
    {
        for (int x = 0; x < DIM_X; x++)
        {
            for (int y = 0; y < DIM_Y; y++)
            {
                //Debug.Log(x + " " + y);
                if (disposizione[x, y] != 0)
                {
                    InfoCelle cellaDaTrovare = GetInfoCelle((byte)x, (byte)y);
                    Vector3 puntoSpawn = cellaDaTrovare.posCella;

                    GameObject pezzo = Instantiate(pezzi[disposizione[x, y]], new Vector3(puntoSpawn.x, puntoSpawn.y, g_transform.position.z - 1), Quaternion.identity);

                    griglia[x, y] = new Tubi(x, y, 0, (tipoPezzo)disposizione[x, y], pezzo);
                    pezzo.GetComponent<Gestore_pezzo>().questo = griglia[x, y];

                    byte rotazioni = (byte)random.Next(0, orientamento.Length);
                    for (int i = 0; i < rotazioni; i++)
                    {
                        pezzo.GetComponent<Gestore_pezzo>().Ruota(); ;
                    }
                    pezziGenerati.Add(pezzo);

                    cellaDaTrovare.pezzoInterno = pezzo;

                    cellaDaTrovare.tipoPezzo = (tipoPezzo)disposizione[x, y];
                }

            }
        }
    }

    public static InfoCelle GetInfoCelle(byte x, byte y)
    {
        List<InfoCelle> Linea = celleGriglia.FindAll(a => a.coordinate.orizzontale == x);

        InfoCelle cella = Linea.Find(b => b.coordinate.verticale == y);

        return cella;
    }

    public void ControllaVincita()
    {
        if (controllaPercorso())
        {
            pannelloFine.SetActive(true);
        }
    }


    public bool controllaPercorso()
    {
        for (int x = 0; x < DIM_X; x++)
        {
            for (int y = 0; y < DIM_Y; y++)
            {
                if (griglia[x,y] != null)
                {
                    if (griglia[x,y].tipoTubo == tipoPezzo.dritto)
                    {
                        if (griglia[x, y].gradi != Modelli.modello1.Soluzione[x, y] && griglia[x, y].gradi + 180 != Modelli.modello1.Soluzione[x, y])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (griglia[x, y].gradi != Modelli.modello1.Soluzione[x, y])
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }


}

public struct Coordinate_scacchiera
{
    public byte orizzontale;
    public byte verticale;
}


public class InfoCelle
{
    public Coordinate_scacchiera coordinate;
    public GameObject pezzoInterno;
    public Vector3 posCella;
    public tipoPezzo tipoPezzo;

    public InfoCelle(byte orizzontale, byte verticale, Vector3 pos, GameObject pezzo = null, tipoPezzo tipo = tipoPezzo.vuoto)
    {
        coordinate.orizzontale = orizzontale;
        coordinate.verticale = verticale;
        pezzoInterno = pezzo;
        posCella = pos;
        tipoPezzo = tipo;
    }
}
