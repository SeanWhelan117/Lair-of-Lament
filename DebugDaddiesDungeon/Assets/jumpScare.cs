using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScare : MonoBehaviour
{
    public ghostSense ghost;
    /// <summary>
    /// if the ghost actually is collding with the player do jumpscare
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ghost.jumpScare();
        }
    }
}
