using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionePallina : MonoBehaviour
{
    public Tubi questo;

    void OnMouseDown()
    {
        if (true)//GestioneGriglia.istanza.giocoAttivo)
        {
            Seleziona();
            GestioneGriglia.istanza.ControllaVincita();
        }
    }

    private void Seleziona()
    {
        Vector3 posizione = transform.position;
        posizione.y = 2.5f;
        transform.position = posizione;
    }
}
