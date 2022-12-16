using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSenseTriggerSlow : MonoBehaviour
{
    public ghostSense ghost;
    /// <summary>
    /// If ghost sense collides with the player,  set the ghosts speed to half what it was originally
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ghost.speed = 0.5f;
        }
    }
}
