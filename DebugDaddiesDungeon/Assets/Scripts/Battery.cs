using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Battery : MonoBehaviour
{
    public torchcontroller torch;
    public float batteryLife= 0;

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
