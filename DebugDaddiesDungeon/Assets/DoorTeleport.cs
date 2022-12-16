using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Transform Target;
    public PlayerFifi player;
    public bool allowTeleport;

    /// <summary>
    /// If allowed to teleport and the E key is pressed transport the player to the other door location
    /// </summary>
    private void Update()
    {
        if (allowTeleport == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerFifi.instance.rb.transform.position = Target.position;
            }
        }
    }
    /// <summary>
    /// Checking for collsions if they are on the door currently
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            allowTeleport = true;
            Debug.Log("enter door");
        }
    }
    /// <summary>
    /// Check if the player is no longer colliding with the door
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            allowTeleport = false;  
            Debug.Log("exit door");
        }
    }
}
