using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vampTransform : MonoBehaviour
{

    public vampEnemyScript enemy;
   
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (enemy.doItOnce == false)
            {
                enemy.transformToVamp();
                enemy.doItOnce = true;
                enemy.sprite.SetBool("transform", true);
                enemy.afterTransform = true;
            }
        }
    }
}
