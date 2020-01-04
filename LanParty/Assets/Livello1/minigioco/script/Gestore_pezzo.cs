using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestore_pezzo : MonoBehaviour
{
    public Tubi questo;

    void OnMouseDown()
    {
        Ruota();
        GesgtioneGriglia.istanza.ControllaVincita();
    }

    public void Ruota()
    {
        transform.Rotate(0, 0, -90);
        questo.gradi = (int)transform.rotation.eulerAngles.z;
        //if (rot > -45 && rot < 45)
        //{
        //    questo.gradi = 0;
        //}
        //else if (rot > 45 && rot < 135)
        //{
        //    questo.gradi = 90;
        //}
        //else if (rot > 135 && rot < 190 || rot > -190 && rot < -135)
        //{
        //    questo.gradi = 180;
        //}
        //else if (rot > -135 && rot < -45)
        //{
        //    questo.gradi = -90;
        //}
        //else
        //{
        //    throw new System.Exception("ciao");
        //}
    }
}
