using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScript : MonoBehaviour
{

    private bool pickupAllowed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// check if Pickups are allowed. If so allow pickup with E
    /// </summary>
    void Update()
    {
        if (pickupAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    /// <summary>
    /// Check for pickups entering collision with the player via tag
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with the Player brother");
            pickupAllowed = true;
        }
    }

    /// <summary>
    /// Check for pickups exitiing collision with the player via tag
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            Debug.Log("leaving the Player brother");
            pickupAllowed = false;
        }
    }

    /// <summary>
    /// destroy the pickup now that it is pickedUp
    /// </summary>
    private void PickUp()
    {
        Destroy(gameObject); //Temp code - We can do whatever we want with pickup
    }
}
