using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene_manager : MonoBehaviour
{
    public Rigidbody2D player;
    public bool stopped = true;
    public int nextScene;
    public Animator animator;



    protected Player_movement pm;
    protected int eventLoader = -3;
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

    public void nextLevel()
    {
        animator.SetTrigger("Fade_out");
    }

    public void OnFadeInComplete()
    {
        TriggerEvent();
    }

    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene(nextScene);
    }



}
