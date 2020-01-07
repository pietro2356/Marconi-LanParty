using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_behaviour : MonoBehaviour
{
    public Transform camera,
        player;

    private void Update()
    {
        transform.position = new Vector3(camera.position.x + player.position.x * -0.01f, camera.position.y + player.position.y * 0.01f);
    }
}
