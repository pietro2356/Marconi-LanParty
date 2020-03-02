using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestoreFormDomande : MonoBehaviour
{
    public start()
    {
        NuovaDomanda();
    }

    public void NuovaDomanda()
    {
        Domanda domanda = GestoreComunicazione.RichiediDomanda();
        question_popup.txtDomanda = domanda[0];
        question_popup.txtOpzione1 = domanda[1];
        question_popup.txtOpzione2 = domanda[2];
        question_popup.txtOpzione3 = domanda[3];
        question_popup.txtOpzione4 = domanda[4];
    }

    public int InvioRisposta(int numero)
    {
        GestoreComunicazione.RispostaDomanda(numero);
    }
}
