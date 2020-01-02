using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Modelli
{
    private static byte[,] base1 = new byte[,]
    {
        { 2, 1, 1, 1, 1, 1 },
        { 1, 1, 0, 0, 0, 0 },
        { 1, 0, 1, 0, 0, 0 },
        { 1, 0, 0, 1, 0, 0 },
        { 1, 0, 0, 0, 4, 0 },
        { 1, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 1, 0 },
        { 1, 0, 0, 1, 0, 0 },
        { 1, 0, 1, 0, 0, 0 },
        { 1, 1, 0, 0, 0, 0 },
        { 3, 0, 0, 0, 0, 0 },
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

    public static Modello modello1 = new Modello(base1);
    public static Modello modello2 = new Modello(base2);
}

public class Modello
{
    byte[,] schema;

    public byte[,] Schema { get => schema; set => schema = value; }

    public Modello(byte[,] schema)
    {
        Schema = schema;
    }
}