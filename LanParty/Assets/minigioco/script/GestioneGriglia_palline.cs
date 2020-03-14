using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestioneGriglia_palline : MonoBehaviour
{
    const byte DIM_X = 6, DIM_Y = 4;
    const byte maxPunti = 50;

    SpriteRenderer g_renderer;
    Transform g_transform;

    [NonSerialized]
    public Vector2 dimCella;

    public Tubi[,] griglia = new Tubi[DIM_X, DIM_Y];

    static List<InfoCelle> celleGriglia;

    public List<GameObject> pezzi = new List<GameObject>();

    public static List<InfoCelle> CelleGriglia
    {
        get { return celleGriglia; }
        set { celleGriglia = value; }
    }

    public static GestioneGriglia_palline istanza;

    public GameObject pannelloIntermedio;
    public GameObject pannelloFine;
    public GameObject ScrittaPunteggio;
    public GameObject ScrittaTempo;

    [NonSerialized]
    public bool giocoAttivo;

    System.Random random = new System.Random();

    byte modelloUsato;

    public GameObject timer;

    byte schema = 0;

    void Awake()
    {
        g_renderer = GetComponent<SpriteRenderer>();
        g_transform = transform;

        celleGriglia = new List<InfoCelle>();

        SetupGriglia();

        istanza = this;

        inizio();
    }

    void inizio()
    {
        modelloUsato = (byte)random.Next(0, Modelli_palline.modelli.Length);

        GeneraPezzi(Modelli_palline.modelli[modelloUsato].Schema);

        giocoAttivo = true;

        timer.GetComponent<Gestore_Timer>().gestore = this;
        timer.GetComponent<Gestore_Timer>().avviaTimer();
    }

    void SetupGriglia()
    {
        celleGriglia.Clear();
        foreach (var pezzo in griglia)
        {
            if (pezzo != null)
            {
                Destroy(pezzo.tubo);
            }
        }
        griglia = new Tubi[DIM_X, DIM_Y];

        Vector3 dimScacchiera = g_renderer.size * g_renderer.transform.localScale;

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
        foreach (var cella in celleGriglia)
        {
            Destroy(cella.pezzoInterno);
            cella.pezzoInterno = null;
        }

        for (int x = 0; x < DIM_X; x++)
        {
            for (int y = 0; y < DIM_Y; y++)
            {
                if (disposizione[x, y] != 0)
                {
                    InfoCelle cellaDaTrovare = GetInfoCelle((byte)x, (byte)y);
                    Vector3 puntoSpawn = cellaDaTrovare.posCella;

                    GameObject pezzo = Instantiate(pezzi[disposizione[x, y]], new Vector3(puntoSpawn.x, puntoSpawn.y, g_transform.position.z - 1), Quaternion.identity);

                    griglia[x, y] = new Tubi(x, y, 0, (tipoPezzo)disposizione[x, y], pezzo);
                    pezzo.GetComponent<GestionePallina>().questo = griglia[x, y];

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
            giocoAttivo = false;
            if (schema == 0)
            {
                pannelloIntermedio.SetActive(true);
            }
            else
            {
                pannelloFine.SetActive(true);
                ScrittaTempo.GetComponent<Text>().text = timer.GetComponent<Gestore_Timer>().testoTimer.text;
                int punteggio = (int)(((float)timer.GetComponent<Gestore_Timer>().orarioPartenza / (float)200) * (float)maxPunti);
                punteggio = maxPunti - punteggio;
                if (punteggio < 0)
                {
                    punteggio = 0;
                }
                ScrittaPunteggio.GetComponent<Text>().text = punteggio + "/" + maxPunti;
                GameObject.FindGameObjectsWithTag("GestoreGioco")[0].GetComponent<GestoreComunicazione>().FineMinigioco(punteggio);
            }
        }
    }

    public void Prosegui()
    {
        SceneManager.LoadScene(5);
    }

    public bool controllaPercorso()
    {
        for (int x = 0; x < DIM_X; x++)
        {
            for (int y = 0; y < DIM_Y; y++)
            {
                if (griglia[x, y] != null)
                {
                    if (Modelli.modelli[modelloUsato].Soluzione[x, y] == -1)
                    {
                    }
                    else if (griglia[x, y].tipoTubo == tipoPezzo.dritto)
                    {
                        if (griglia[x, y].gradi != Modelli.modelli[modelloUsato].Soluzione[x, y] && griglia[x, y].gradi + 180 != Modelli.modelli[modelloUsato].Soluzione[x, y] && griglia[x, y].gradi - 180 != Modelli.modelli[modelloUsato].Soluzione[x, y])
                        {
                            return false;
                        }
                    }
                    else if (griglia[x, y].tipoTubo == tipoPezzo.quatroUscite)
                    {
                    }
                    else
                    {
                        if (griglia[x, y].gradi != Modelli.modelli[modelloUsato].Soluzione[x, y])
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    public void InizioIntermedio()
    {
        pannelloIntermedio.SetActive(false);
        schema++;
        inizio();
    }
}


public class InfoCelle_palline
{
    public Coordinate_scacchiera coordinate;
    public GameObject pezzoInterno;
    public Vector3 posCella;
    public tipoPezzo tipoPezzo;

    public InfoCelle_palline(byte orizzontale, byte verticale, Vector3 pos, GameObject pezzo = null, tipoPezzo tipo = tipoPezzo.vuoto)
    {
        coordinate.orizzontale = orizzontale;
        coordinate.verticale = verticale;
        pezzoInterno = pezzo;
        posCella = pos;
        tipoPezzo = tipo;
    }
}

