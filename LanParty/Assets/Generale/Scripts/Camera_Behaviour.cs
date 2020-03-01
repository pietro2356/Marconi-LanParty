using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Behaviour : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float leftLimit,
        rightLimit,
        topLimit,
        bottomLimit,
        speed;
    public bool isFixed = false;


    void FixedUpdate()
    {
        if (!isFixed)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, speed);
            transform.position = new Vector3(Mathf.Clamp(smoothPosition.x, leftLimit, rightLimit), Mathf.Clamp(smoothPosition.y, bottomLimit, topLimit), smoothPosition.z);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit));
    }

}
