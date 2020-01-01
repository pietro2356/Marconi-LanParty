using System.Collections;
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

    byte[,] prova = new byte[,] {
        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } ,
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } ,
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

    void Awake()
    {
        g_renderer = GetComponent<SpriteRenderer>();
        g_transform = transform;

        celleGriglia = new List<InfoCelle>();

        SetupGriglia();

        GeneraPezzi(prova);
    }

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
                Vector3 posCella = new Vector3(posStart.x + (dimCella.x * j), posStart.y + (dimCella.y * i));

                InfoCelle cella = new InfoCelle(orizzontale, verticale, posCella);

                CelleGriglia.Add(cella);
            }
        }
    }

    void GeneraPezzi(byte[,] disposizione)
    {
        for (int i = 0; i < DIM_X; i++)
        {
            for (int j = 0; j < DIM_Y; j++)
            {
                Debug.Log(i + " " + j);
                if (disposizione[j, i] != 0)
                {
                    InfoCelle cellaDaTrovare = GetInfoCelle((byte)i, (byte)j);
                    Vector3 puntoSpawn = cellaDaTrovare.posCella;

                    GameObject pezzo = Instantiate(pezzi[disposizione[j, i]], new Vector3(puntoSpawn.x, puntoSpawn.y, g_transform.position.z - 1), Quaternion.identity);
                    pezziGenerati.Add(pezzo);

                    cellaDaTrovare.pezzoInterno = pezzo;

                    cellaDaTrovare.tipoPezzo = (tipoPezzo)disposizione[j, i];
                }

                //Coordinate_scacchiera coord = new Coordinate_scacchiera();
                //coord.lettera = cellaDaTrovare.coordinate.lettera;
                //coord.numero = cellaDaTrovare.coordinate.numero;

                //manager_pezzi mp = pezzo.GetComponent<manager_pezzi>();
                //mp.mieCoordinate = coord;

            }
        }
    }

    public static InfoCelle GetInfoCelle(byte x, byte y)
    {
        List<InfoCelle> Linea = celleGriglia.FindAll(a => a.coordinate.orizzontale == x);

        InfoCelle cella = Linea.Find(b => b.coordinate.verticale == y);

        return cella;
    }


    public bool controllaPercorso()
    {
        throw new NotImplementedException();
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
