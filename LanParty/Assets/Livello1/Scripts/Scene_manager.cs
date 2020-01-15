using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_manager : MonoBehaviour
{
    protected Player_movement pm;
    protected int eventLoader = -2;
    public bool stopped = false;


    public void TriggerEvent()
    {
        eventLoader++;
    }

}
