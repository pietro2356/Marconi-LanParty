using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_manager : MonoBehaviour
{
    public Rigidbody2D player;
    public bool stopped = true;


    protected Player_movement pm;
    protected int eventLoader = -2;
    protected Dialog_Manager DM;
    protected Gestore_File GF = new Gestore_File();
    protected bool firstTime = true;

    private void Start()
    {
        pm = FindObjectOfType<Player_movement>();
        DM = FindObjectOfType<Dialog_Manager>();
        
    }

    public void TriggerEvent()
    {
        eventLoader++;
    }



}
