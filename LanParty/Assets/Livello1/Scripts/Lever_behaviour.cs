using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_behaviour : MonoBehaviour
{
    public bool isActivated = false;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
            sprite.color = Color.yellow;
        else
            sprite.color = Color.gray;
            
    }
}
