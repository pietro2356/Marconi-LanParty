using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_behaviour : MonoBehaviour
{
    public SpriteRenderer lever;
    public float Xmovement, Ymovement;
    public bool animated;

    private Vector3 originalPosition,
        newPosition;




    void Start()
    {
        originalPosition = transform.position;
        newPosition = new Vector3(originalPosition.x + Xmovement, originalPosition.y + Ymovement);
        if (!lever.GetComponent<Lever_behaviour>().isActivated)
            transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        bool active = lever.GetComponent<Lever_behaviour>().isActivated;



        if (animated)
        {
            if (active)
            {
                if (Xmovement != 0)
                    if (originalPosition.x > newPosition.x)
                    {
                        if (transform.position.x < originalPosition.x)
                            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y);
                    }
                    else
                    {
                        if (transform.position.x > originalPosition.x)
                            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);
                    }

                if (Ymovement != 0)
                    if (originalPosition.y > newPosition.y)
                    {
                        if (transform.position.y < originalPosition.y)
                            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f);
                    }
                    else
                    {
                        if (transform.position.y > originalPosition.y)
                            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f);
                    }
            }
            else
            {
                if (Xmovement != 0)
                    if (originalPosition.x > newPosition.x)
                    {
                        if (transform.position.x > newPosition.x)
                            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y);
                    }
                    else
                    {
                        if (transform.position.x < newPosition.x)
                            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y);
                    }

                if (Ymovement != 0)
                    if (originalPosition.y > newPosition.y)
                    {
                        if (transform.position.y > newPosition.y)
                            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f);
                    }
                    else
                    {
                        if (transform.position.y < newPosition.y)
                            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f);
                    }
            }

            //y1>y2 => più in basso
            //x1>x2 => più a destra
        }
        else
        {
            if (active)
                transform.position = originalPosition;
            else
                transform.position = newPosition;
        }
    }


}
