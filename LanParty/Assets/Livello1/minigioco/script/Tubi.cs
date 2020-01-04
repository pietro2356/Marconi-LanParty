using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public enum tipoPezzo
{
    vuoto,
    dritto,
    curva,
    treUsite,
    quatroUscite
}

public class Tubi
{
    public int x;
    public int y;
    public float gradi;
    public tipoPezzo tipoTubo;
    public GameObject tubo;

    public Tubi(int x, int y, float gradi, tipoPezzo tipoTubo, GameObject tubo)
    {
        this.x = x;
        this.y = y;
        this.gradi = gradi;
        this.tipoTubo = tipoTubo;
        this.tubo = tubo;
    }
}
