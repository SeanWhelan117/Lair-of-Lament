using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomOutCall : MonoBehaviour
{
    public CameraScript camera;
    /// <summary>
    /// Can zoom out when the camera is colliding with the player
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camera.zoomOut = true;
        }
    }
}
