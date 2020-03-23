using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestioneRisposte : MonoBehaviour
{
    public Dialog_Manager DM;

    void Start()
    {
        DM = FindObjectOfType<Dialog_Manager>();
    }

    public void Risposta(int risposta)
    {
        Debug.Log(risposta);
        DM.Risposta(risposta);
    }
}
