using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionePallina : MonoBehaviour
{
    public Coordinate_scacchiera posizione;
    public byte colore;
    bool su = false;
    bool torna = false;
    bool vai = false;
    Vector3 pos;
    bool orizzontale = true;
    bool prima = false;

    void OnMouseDown()
    {
        //Debug.Log("pallina" +posizione.orizzontale + posizione.verticale);
        if (true)//GestioneGriglia.istanza.giocoAttivo)
        {
            if (GestioneGriglia_palline.istanza.isSopra(posizione))
            {
                Seleziona();
                GestioneGriglia_palline.istanza.pallinaSelezionata = this;
                GestioneGriglia_palline.istanza.AbilitaColonne();
            }
        }
    }

    private void Seleziona()
    {
        su = true;
    }

    public void Torna(Vector3 pos)
    {
        this.pos = pos;
        torna = true;
    }

    public void VaiA (Vector3 pos)
    {
        if (pos.x < transform.position.x)
        {
            prima = true;
        }
        else
        {
            prima = false;
        }
        this.pos = pos;
        orizzontale = true;
        vai = true;
    }

    private void Update()
    {
        if (su)
        {
            Vector3 posizione = transform.position;
            posizione.y += 0.2f;
            if (posizione.y >= 2.5f)
            {
                posizione.y = 2.5f;
                su = false;
            }
            transform.position = posizione;
        }

        if (torna)
        {
            Vector3 posizione = transform.position;
            posizione.y -= 0.2f;
            if (posizione.y <= pos.y)
            {
                posizione.y = pos.y;
                torna = false;
            }
            transform.position = posizione;
        }

        if (vai)
        {
            if (orizzontale)
            {
                if (prima)
                {
                    Vector3 posizione = transform.position;
                    posizione.x -= 0.2f;
                    if (posizione.x <= pos.x)
                    {
                        posizione.x = pos.x;
                        orizzontale = false;
                    }
                    transform.position = posizione;
                }
                else
                {
                    Vector3 posizione = transform.position;
                    posizione.x += 0.2f;
                    if (posizione.x >= pos.x)
                    {
                        posizione.x = pos.x;
                        orizzontale = false;
                    }
                    transform.position = posizione;
                }
            }
            else
            {
                Vector3 posizione = transform.position;
                posizione.y -= 0.2f;
                if (posizione.y <= pos.y)
                {
                    posizione.y = pos.y;
                    vai = false;
                }
                transform.position = posizione;
            }
            
        }
    }
}
