using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Manager : MonoBehaviour
{
    public GameObject sentencePreFab;
    public GameObject questionPreFab;
    public Queue<string> sentences;
    public bool inDialog = false,
        isTrigger;

    private GameObject popUp;
    private Text[] texts;
    private FirstLevel_script level;


    void Start()
    {
        sentences = new Queue<string>();
        level = FindObjectOfType<FirstLevel_script>();
    }

    public void StartDialogue(string[] dialogue)
    {
        level.stopped = true;

        popUp = Instantiate(sentencePreFab) as GameObject;


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

    void Update()
    {
        if (inDialog)
            level.stopped = true;
    }
}
