using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_behaviour : MonoBehaviour
{
    public Transform camera;
    public Vector2 offset;

    private void Update()
    {
        transform.position = new Vector3(camera.position.x + offset.x +  camera.position.x * -0.05f, camera.position.y + offset.y + camera.position.y * -0.05f);
    }
}
