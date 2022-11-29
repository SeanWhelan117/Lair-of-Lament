using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Transform Target;
    public PlayerFifi player;
    public bool allowTeleport;


    private void Update()
    {
        if (allowTeleport == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                player.rb.transform.position = Target.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            allowTeleport = true;
            Debug.Log("enter door");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            allowTeleport = false;  
            Debug.Log("exit door");
        }
    }
}
