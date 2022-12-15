using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSenseTriggerSlow : MonoBehaviour
{
    public ghostSense ghost;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ghost.speed = 0.5f;
        }
    }
}
