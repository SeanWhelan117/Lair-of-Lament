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
    void Update()
    {
        if (pickupAllowed && Input.GetKeyDown(KeyCode.E))
            PickUp();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with the Player brother");
            pickupAllowed = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pickup")
        {
            Debug.Log("leaving the Player brother");
            pickupAllowed = false;
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}
