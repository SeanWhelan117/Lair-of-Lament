using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdam : MonoBehaviour
{
    float speed = 5;
    Rigidbody2D _rb;
    Vector2 movement;

    // Start is called before the first frame update
    /// <summary>
    /// Just gets the rigidbody Component of the player
    /// </summary>
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /// <summary>
    /// Does the playes movement
    /// </summary>
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    /// <summary>
    /// Calls the players movement 
    /// </summary>
    private void FixedUpdate()
    {
        movePlayer(movement);
    }

    /// <summary>
    /// Moves the player with the rigidbody 
    /// </summary>
    /// <param name="direction"></param>
    void movePlayer(Vector2 direction)
    {
        _rb.AddForce(direction * speed);
    }



}
