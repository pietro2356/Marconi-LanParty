using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public enum tipoPezzo_Colori
{
    vuoto,
    dritto,
    curva,
    palla
}

public class Linea_Colori
{
    public int x;
    public int y;
    public int gradi;
    public tipoPezzo tipoLinea;
    public GameObject linea;

    public Linea_Colori(int x, int y, int gradi, tipoPezzo tipoLinea, GameObject linea)
    {
        this.x = x;
        this.y = y;
        this.gradi = gradi;
        this.tipoLinea = tipoLinea;
        this.linea = linea;
    }
}

public enum Colori
{

}
