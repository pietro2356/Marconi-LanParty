using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestione_colonne : MonoBehaviour
{
    public byte posizione; 

    void OnMouseDown()
    {
        //Debug.Log("rettangolo " + posizione);
        GestioneGriglia_palline.istanza.InserisciPallina(posizione);
    }
}
