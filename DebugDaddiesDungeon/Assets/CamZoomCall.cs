using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomCall : MonoBehaviour
{

    public CameraScript camera;
    /// <summary>
    /// Camera can zoom when the collision with player is true
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camera.zoom = true;
        }
    }
}
