using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdam : MonoBehaviour
{
    float speed = 5;
    Rigidbody2D _rb;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        movePlayer(movement);
    }

    void movePlayer(Vector2 direction)
    {
        _rb.AddForce(direction * speed);
    }



}
