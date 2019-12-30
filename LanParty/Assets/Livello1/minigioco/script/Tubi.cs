using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public enum tipoTubo
{
    DRITTO, CURVA
}

public class Tubi : MonoBehaviour
{
    public int x;
    public int y;
    public float gradi;
    public tipoTubo tipoTubo;

    public Tubi(int x, int y, float gradi, tipoTubo tipoTubo)
    {
        this.x = x;
        this.y = y;
        this.gradi = gradi;
        this.tipoTubo = tipoTubo;
    }
}
