using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public enum tipoPezzo
{
    vuoto,
    dritto,
    curva
}

public class Tubi : MonoBehaviour
{
    public int x;
    public int y;
    public float gradi;
    public tipoPezzo tipoTubo;

    public Tubi(int x, int y, float gradi, tipoPezzo tipoTubo)
    {
        this.x = x;
        this.y = y;
        this.gradi = gradi;
        this.tipoTubo = tipoTubo;
    }
}
