using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_behaviour : MonoBehaviour
{
    public float first_floor,
        second_floor,
        third_floor;

    private Transform original_position;
    private float initial_time;
    private void Start()
    {
        original_position = transform;
    }

    private void Update()
    {
        
        MoveElevator(first_floor);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector2(transform.position.x - 1, transform.position.y + first_floor), new Vector2(transform.position.x + 1, transform.position.y + first_floor));
        Gizmos.DrawLine(new Vector2(transform.position.x - 1, transform.position.y + second_floor), new Vector2(transform.position.x + 1, transform.position.y + second_floor));
        Gizmos.DrawLine(new Vector2(transform.position.x - 1, transform.position.y + third_floor), new Vector2(transform.position.x + 1, transform.position.y + third_floor));

    }

    private void MoveElevator(float floor)
    {
        if (initial_time == 0)
        {
            initial_time = Time.time;

        }
        else if (Time.time - initial_time < 5)
        {
            if (transform.position.y < original_position.position.y + floor)
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        }
        else
        {
            initial_time = 0;
        }
    }
}
