using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Modelli_palline
{
    private static byte[,] base0 = new byte[,]
    {
        { 1, 2, 4, 3 },
        { 3, 4, 3, 1 },
        { 1, 4, 4, 2 },
        { 2, 1, 3, 2 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 0 },
    };

    private static byte[,] base1 = new byte[,]
    {
        { 1, 4, 2, 2 },
        { 3, 3, 2, 4 },
        { 4, 4, 1, 1 },
        { 1, 3, 3, 2 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 0 },
    };


    private static byte[,] base2 = new byte[,]
    {
        { 2, 2, 4, 3 },
        { 3, 2, 2, 4 },
        { 1, 4, 1, 3 },
        { 3, 1, 4, 1 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 0 },
    };

    private static byte[,] base3 = new byte[,]
    {
        { 1, 4, 1, 1 },
        { 3, 4, 2, 3 },
        { 2, 2, 3, 3 },
        { 1, 4, 2, 4 },
        { 0, 0, 0, 0 },
        { 0, 0, 0, 0 },
    };

    public static modello_palline[] modelli = new modello_palline[] { new modello_palline(base0), new modello_palline(base1), new modello_palline(base2), new modello_palline(base3) };
}

public class modello_palline
{
    public byte[,] Schema;

    public modello_palline(byte[,] schema)
    {
        Schema = schema;
    }
}
