using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostSenseTrigger : MonoBehaviour
{
    public ghostSense ghost;
    /// <summary>
    /// if the ghostSense is colliding with the player, ghost. move is true
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ghost.move = true;
        }
    }
}
