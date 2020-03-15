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

    static List<InfoCelle_palline> celleGriglia;

    public List<GameObject> pezzi = new List<GameObject>();

    public static List<InfoCelle_palline> CelleGriglia
    {
        get { return celleGriglia; }
        set { celleGriglia = value; }
    }

    public GameObject colonna;
    [NonSerialized]
    public List<GameObject> colonne = new List<GameObject>();

    public GestionePallina pallinaSelezionata;

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

        celleGriglia = new List<InfoCelle_palline>();

        SetupGriglia();

        istanza = this;

        SetupColonne();

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

                InfoCelle_palline cella = new InfoCelle_palline(orizzontale, verticale, posCella);

                CelleGriglia.Add(cella);
            }
        }
    }

    void SetupColonne()
    {
        foreach (var col in colonne)
        {
            Destroy(col);
        }
        colonne.Clear();

        Vector3 dimScacchiera = g_renderer.size * g_renderer.transform.localScale;
        Vector2 dimColonna = new Vector2((dimScacchiera.x - 0.06f) / DIM_X, 0);
        Vector3 posIniziale = new Vector3((g_transform.position.x - ((dimScacchiera.x - 0.06f) / 2)) + (dimColonna.x / 2), 0);

        for (byte i = 0; i < DIM_X; i++)
        {

            byte orizzontale = i;
            Vector3 posCella = new Vector3(posIniziale.x + (dimCella.x * i), transform.position.y);

            GameObject pezzo = Instantiate(colonna, new Vector3(posCella.x, posCella.y, g_transform.position.z - 2), Quaternion.identity);

            pezzo.GetComponent<Gestione_colonne>().posizione = i;

            colonne.Add(pezzo);
        }
    }

    void GeneraPezzi(byte[,] disposizione)
    {
        foreach (var cella in celleGriglia)
        {
            Destroy(cella.pezzoInterno);
            cella.pezzoInterno = null;
        }

        for (byte x = 0; x < DIM_X; x++)
        {
            for (byte y = 0; y < DIM_Y; y++)
            {
                if (disposizione[x, y] != 0)
                {
                    InfoCelle_palline cellaDaTrovare = GetInfoCelle(x, y);
                    Vector3 puntoSpawn = cellaDaTrovare.posCella;

                    GameObject pezzo = Instantiate(pezzi[disposizione[x, y]], new Vector3(puntoSpawn.x, puntoSpawn.y, g_transform.position.z - 1), Quaternion.identity);

                    pezzo.GetComponent<GestionePallina>().posizione = new Coordinate_scacchiera(x, y);

                    cellaDaTrovare.pezzoInterno = pezzo;
                }

            }
        }
    }

    public static InfoCelle_palline GetInfoCelle(byte x, byte y)
    {
        List<InfoCelle_palline> Linea = celleGriglia.FindAll(a => a.coordinate.orizzontale == x);

        InfoCelle_palline cella = Linea.Find(b => b.coordinate.verticale == y);

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
        int i = 0;
        byte col = 0;
        for (int x = 0; x < DIM_X; x++)
        {
            for (int y = 0; y < DIM_Y; y++)
            {
                byte buffer = 0;
                try
                {
                    buffer = celleGriglia[i].pezzoInterno.GetComponent<GestionePallina>().colore;
                }
                catch (Exception)
                {
                }

                if (y == 0)
                {
                    col = buffer;
                }
                else
                {
                    if (col != buffer)
                    {
                        return false;
                    }
                }
                i++;
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

    public bool isSopra(Coordinate_scacchiera coordinate)
    {
        for (byte i = (byte)(coordinate.verticale + 1); i < DIM_Y; i++)
        {
            InfoCelle_palline cella = GetInfoCelle(coordinate.orizzontale, i);
            if (cella.pezzoInterno != null)
            {
                return false;
            }
        }
        return true;
    }

    public void AbilitaColonne()
    {
        foreach (var col in colonne)
        {
            col.SetActive(true);
        }
    }

    public void DisabilitaColonne()
    {
        foreach (var col in colonne)
        {
            col.SetActive(false);
        }
    }

    public void InserisciPallina(byte pos)
    {
        GameObject pallina = pallinaSelezionata.gameObject;

        if (pos == pallinaSelezionata.posizione.orizzontale)
        {
            pallina.transform.position = GetInfoCelle(pos, pallinaSelezionata.posizione.verticale).posCella;
            pallinaSelezionata = null;
            DisabilitaColonne();
            return;
        }

        byte max = 20;

        for (byte i = 0; i < DIM_Y; i++)
        {
            InfoCelle_palline cella = GetInfoCelle(pos, i);
            if (cella.pezzoInterno == null)
            {
                max = i;
                break;
            }
        }

        if (max == 20)
        {
            return;
        }

        if (max != 0 && GetInfoCelle(pos, (byte)(max - 1)).pezzoInterno.GetComponent<GestionePallina>().colore != pallinaSelezionata.colore)
        {
            return;
        }

        GetInfoCelle(pallinaSelezionata.posizione.orizzontale, pallinaSelezionata.posizione.verticale).pezzoInterno = null;
        InfoCelle_palline des = GetInfoCelle(pos, max);
        des.pezzoInterno = pallina;
        pallina.transform.position = des.posCella + new Vector3(0,0, -1);

        pallinaSelezionata = null;

        DisabilitaColonne();

        ControllaVincita();
    }
}


public class InfoCelle_palline
{
    public Coordinate_scacchiera coordinate;
    public GameObject pezzoInterno;
    public Vector3 posCella;

    public InfoCelle_palline(byte orizzontale, byte verticale, Vector3 pos, GameObject pezzo = null)
    {
        coordinate.orizzontale = orizzontale;
        coordinate.verticale = verticale;
        pezzoInterno = pezzo;
        posCella = pos;
    }
}

