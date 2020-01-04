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
        { 1, 0, 0, 0, 0, 2 },
        { 2, 0, 0, 0, 0, 1 },
        { 3, 0, 0, 0, 2, 2 },
        { 4, 0, 0, 0, 1, 0 },
        { 0, 0, 0, 0, 3, 2 },
        { 0, 0, 0, 0, 3, 2 },
        { 0, 0, 0, 0, 1, 0 },
        { 2, 1, 3, 1, 2, 0 },
        { 3, 1, 2, 0, 0, 0 },
        { 1, 0, 0, 0, 0, 0 },
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
        { -180, 0, 0, 0, 0, 0 },
    };

    public static Modello modello1 = new Modello(base1, soluzione1);
    public static Modello modello2 = new Modello(base2, soluzione1);
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