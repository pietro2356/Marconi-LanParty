using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator_behaviour : MonoBehaviour
{
    public List<float> floors;
    

    private Transform original_position;
    private float initial_time;
    private int actualFloor = 0;
    private void Start()
    {
        floors.Add(0);
        original_position = transform;
    }

    private void Update()
    {
        MoveElevator(actualFloor);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        foreach (var singleFloor in floors)
        {
            Gizmos.DrawLine(new Vector2(transform.position.x - 1, transform.position.y + singleFloor), new Vector2(transform.position.x + 1, transform.position.y + singleFloor));
        }

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
            actualFloor++;
        }
    }
}
