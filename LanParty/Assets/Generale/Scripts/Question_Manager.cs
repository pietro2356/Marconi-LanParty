﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question_Manager : MonoBehaviour
{
    public GameObject sentencePreFab;
    public GameObject questionPreFab;
    public Queue<string> sentences;
    public bool inDialog = false,
        isTrigger;

    private GameObject popUp;
    private Text[] texts;
    private Scene_manager level;

    void Start()
    {
        sentences = new Queue<string>();
        level = FindObjectOfType<Scene_manager>();
    }

    public void StartDialogue(string[] dialogue)
    {
        level.stopped = true;

        popUp = Instantiate(questionPreFab) as GameObject;


        texts = popUp.GetComponentsInChildren<Text>();

        sentences.Clear();



        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }


        inDialog = true;

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        if (sentence.StartsWith("_Q"))
        {
            GameObject qPopUp = Instantiate(questionPreFab) as GameObject;


        }
        else
        {
            string[] dialogue = sentence.Split(';');
            texts[0].text = dialogue[0];
            texts[1].text = dialogue[1];
        }
    }

    public void EndDialogue()
    {
        if (isTrigger)
            level.TriggerEvent();
        isTrigger = false;
        inDialog = false;
        level.stopped = false;
        Destroy(popUp);
        Debug.Log("conversation ended");
    }

    public int GetSentenceNumber()
    {
        if (inDialog)
            return sentences.Count;
        else
            return -1;
    }

    void Update()
    {
        if (inDialog)
            level.stopped = true;
    }


}
