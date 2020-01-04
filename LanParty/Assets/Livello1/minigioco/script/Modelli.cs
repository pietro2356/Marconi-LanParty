using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Modelli
{
    private static byte[,] base1 = new byte[,]
    {
        { 2, 1, 1, 1, 1, 1 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
        { 2, 0, 0, 0, 0, 0 },
    };

    private static byte[,] base2 = new byte[,]
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

    private static int[,] soluzione1 = new int[,]
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

    private static int[,] soluzione2 = new int[,]
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

    public static Modello modello1 = new Modello(base1, soluzione1);
    public static Modello modello2 = new Modello(base2, soluzione2);
}

public class Modello
{
    byte[,] schema;
    int[,] soluzione;

    public Modello(byte[,] schema, int[,] soluzione)
    {
        Schema = schema;
        Soluzione = soluzione;
    }

    public byte[,] Schema { get => schema; set => schema = value; }
    public int[,] Soluzione { get => soluzione; set => soluzione = value; }

}