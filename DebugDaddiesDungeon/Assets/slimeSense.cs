using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeSense : MonoBehaviour
{

    /// <summary>
    /// slime detecting player near by
    /// </summary>
    public SlmieScript slime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slime.inZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slime.inZone = false;
        }
    }
}
