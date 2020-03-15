using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionePallina : MonoBehaviour
{
    public Coordinate_scacchiera posizione;
    public byte colore;

    void OnMouseDown()
    {
        Debug.Log("pallina" +posizione.orizzontale + posizione.verticale);
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
        Vector3 posizione = transform.position;
        posizione.y = 2.5f;
        transform.position = posizione;
    }
}
