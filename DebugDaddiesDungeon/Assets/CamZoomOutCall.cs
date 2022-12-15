using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomOutCall : MonoBehaviour
{
    public CameraScript camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camera.zoomOut = true;
        }
    }
}
