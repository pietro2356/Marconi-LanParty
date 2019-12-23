using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_behaviour : MonoBehaviour
{
    public SpriteRenderer SR;
    public float Xmovement, Ymovement;
    public bool animated;

    private Vector3 originalPosition,
        newPosition;




    void Start()
    {
        originalPosition = transform.position;
        newPosition = new Vector3(originalPosition.x + Xmovement, originalPosition.y + Ymovement);
        if (!SR.GetComponent<Lever_behaviour>().isActivated)
            transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        bool active = SR.GetComponent<Lever_behaviour>().isActivated;



        //if (animated)
        //{
        //    if (active)
        //        transform.position = new Vector3(transform.position.x - (Xmovement * 0.01f), transform.position.y - (Ymovement * 0.01f));
        //    else
        //        transform.position = new Vector3(transform.position.x + (Xmovement * 0.1f), transform.position.y + (Ymovement * 0.1f));
        //}
        //else
        {
            if (active)
                transform.position = originalPosition;
            else
                transform.position = newPosition;
        }
    }
}
