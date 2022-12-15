using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackVamp : MonoBehaviour
{

    public vampEnemyScript enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            enemy.sprite.SetBool("atc", true);
            enemy.box.size = new Vector2(0.7f, 1.5f);
            //player.TakeDamage(randomDmg);
            Debug.Log("att");
            enemy.speed = 0.0f;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.sprite.SetBool("atc", false);
            enemy.box.size = new Vector2(0.7f, 0.9f);

            enemy.speed = 0.06f;
        }
    }
}
