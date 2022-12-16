using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Battery : MonoBehaviour
{
    public torchcontroller torch;
    public float batteryLife= 0;

    /// <summary>
    /// Checks for collision with the player via tags.
    /// If thats the case then the battery is consumed and adds to the battery level of the torch
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            batteryLife = Random.Range(300.0f, 370.0f);
            Debug.Log("battery grabbed");
            torch.lifetime += batteryLife;
            torch.broken = false;
            if (torch.lifetime >= torch.maxBatteryLife)
            {
                torch.lifetime = torch.maxBatteryLife;
            }
            Destroy(this.gameObject);
        }

    }
}
