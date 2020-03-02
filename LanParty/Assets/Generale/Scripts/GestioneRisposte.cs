using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestioneRisposte : MonoBehaviour
{
    private Dialog_Manager DM;

    void Start()
    {
        DM = GetComponent<Dialog_Manager>();
    }

    public void Risposta(int risposta)
    {
        DM.Risposta(risposta);
    }
}
