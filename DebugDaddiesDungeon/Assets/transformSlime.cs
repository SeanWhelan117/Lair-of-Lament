using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformSlime : MonoBehaviour
{
    /// <summary>
    /// allowing slime to transform into boss
    /// </summary>
    public SlmieScript slime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

            slime.transformBoss = true;

        }
    }
}
