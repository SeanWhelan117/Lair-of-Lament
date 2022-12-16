using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public MoveEnemy enemy;

    public float speed = 2.0f;
    private Vector2 pos;
    public short damage = 5;

    /// <summary>
    /// Adds to the enemies postion with a set speed
    /// </summary>
    private void FixedUpdate()
    {
        pos = enemy.transform.position;
        enemy.transform.position = new Vector2(pos.x + speed * Time.deltaTime, 0);
    }

    /// <summary>
    /// Checks for collision with the wall.
    /// If it collides then turn around and walk the opposite direction.
    /// This is for the easy grunt style skeleton enemy which effectively just walks back and forth 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("I changed my speed and rotation");
            speed = -speed;
            enemy.transform.eulerAngles = new Vector3(enemy.transform.eulerAngles.x, 
                                                   enemy.transform.eulerAngles.y + 180, 
                                                   enemy.transform.eulerAngles.z);
        }
    }
}
