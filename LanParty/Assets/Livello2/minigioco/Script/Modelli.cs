﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Modelli_colori
{
    private static byte[,] base0 = new byte[,]
    {
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0 },
    };

    private static byte[,] base1 = new byte[,]
    {
        { 0, 0, 2, 1, 2, 1 },
        { 0, 0, 1, 4, 1, 3 },
        { 0, 0, 2, 2, 3, 2 },
        { 0, 0, 1, 1, 1, 1 },
        { 0, 0, 2, 2, 2, 1 },
        { 0, 2, 1, 3, 1, 2 },
        { 0, 1, 4, 1, 1, 2 },
        { 3, 2, 2, 0, 0, 0 },
        { 2, 2, 3, 0, 0, 0 },
        { 2, 3, 2, 0, 0, 0 },
        { 2, 0, 0, 0, 0, 0 },
    };

    private static byte[,] base2 = new byte[,]
    {
        { 0, 0, 0, 2, 1, 1 },
        { 0, 0, 3, 1, 2, 0 },
        { 0, 0, 1, 1, 3, 0 },
        { 0, 0, 1, 3, 1, 2 },
        { 0, 2, 2, 1, 2, 1 },
        { 0, 3, 2, 3, 1, 2 },
        { 0, 2, 1, 2, 1, 1 },
        { 1, 2, 2, 1, 0, 0 },
        { 2, 1, 3, 1, 0, 0 },
        { 1, 1, 1, 0, 0, 0 },
        { 1, 2, 0, 0, 0, 0 },
    };

    private static byte[,] base3 = new byte[,]
    {
        { 0, 0, 1, 2, 1, 1 },
        { 0, 2, 3, 1, 2, 0 },
        { 0, 0, 1, 1, 0, 0 },
        { 0, 0, 3, 2, 2, 4 },
        { 2, 1, 3, 1, 2, 1 },
        { 1, 2, 1, 2, 2, 0 },
        { 2, 1, 4, 1, 2, 0 },
        { 0, 0, 2, 3, 2, 0 },
        { 0, 2, 2, 1, 4, 0 },
        { 2, 1, 1, 2, 2, 0 },
        { 2, 2, 3, 2, 0, 0 },
    };

    private static int[,] soluzione0 = new int[,]
    {
        { 0, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 90, 0, 0, 0, 0, 0 },
        { 180, 0, 0, 0, 0, 0 },
    };

    private static int[,] soluzione1 = new int[,]
    {
        { -1, -1, -1, -1, 0, 0 },
        { -1, -1, -1, -1, 90, -1 },
        { -1, -1, -1, -1, 270, 270 },
        { -1, -1, -1, -1, 90, 90 },
        { -1, -1, -1, 0, 180, 90 },
        { -1, 0, 0, 0, 0, 180 },
        { -1, 90, -1, -1, -1, -1 },
        { -1, 90, 270, -1, -1, -1 },
        { -1, 0, 90, -1, -1, -1 },
        { 0, 0, 180, -1, -1, -1 },
        { 180, -1, -1, -1, -1, -1 },
    };

    private static int[,] soluzione2 = new int[,]
    {
        { -1, -1, -1, 0, 0, 0 },
        { -1, -1, -1, 90, -1, -1 },
        { -1, -1, -1, 90, -1, -1 },
        { -1, -1, -1, 270, 0, 270 },
        { -1, -1, -1, 90, -1, 90 },
        { -1, -1, 0, 0, 0, 180 },
        { -1, -1, 90, -1, -1, -1 },
        { -1, 0, 180, -1, -1, -1 },
        { -1, 90, -1, -1, -1, -1 },
        { -1, 90, -1, -1, -1, -1 },
        { 0, 180, -1, -1, -1, -1 },
    };

    private static int[,] soluzione3 = new int[,]
    {
        { -1, -1, -1, 0, 0, 0 },
        { -1, -1, -1, 90, -1, -1 },
        { -1, -1, -1, 90, -1, -1 },
        { -1, -1, -1, 90, 270, -1 },
        { 0, 0, 180, 0, 180, -1 },
        { 90, -1, 90, -1, -1, -1 },
        { 90, 0, 0, 0, 270, -1 },
        { -1, -1, 90, 180, 180, -1 },
        { -1, -1, -1, 90, -1, -1 },
        { 0, 0, 0, 180, -1, -1 },
        { 180, -1, -1, -1, -1, -1 },
    };

    public static Modello_colori[] modelli = new Modello_colori[] { new Modello_colori(base0, soluzione0), new Modello_colori(base1, soluzione1), new Modello_colori(base2, soluzione2), new Modello_colori(base3, soluzione3) };
}

public class Modello_colori
{
    byte[,] schema;
    int[,] soluzione;

    public Modello_colori(byte[,] schema, int[,] soluzione)
    {
        Schema = schema;
        Soluzione = soluzione;
    }

    public byte[,] Schema { get => schema; set => schema = value; }
    public int[,] Soluzione { get => soluzione; set => soluzione = value; }

}