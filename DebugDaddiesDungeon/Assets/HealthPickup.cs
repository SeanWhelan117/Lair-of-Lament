using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject powerUp;
    public Vector3 initialPos;
    public Vector3 newPos;

    private float upperLimit, lowerLimit;

    public bool movingDown, movingUp;


    // Start is called before the first frame update
    /// <summary>
    /// Set the initial powerup to moving down and its initial pos and new pos are set
    /// Also gets reference to the player
    /// </summary>
    void Start()
    {
        initialPos = powerUp.transform.position;
        newPos = initialPos;
        movingDown = true;
        movingUp = false;
        upperLimit = initialPos.y - 0.4f;
        lowerLimit = initialPos.y + 0.4f;

    }

    // Update is called once per frame
    /// <summary>
    /// Checks if the powerup is outside the upper/ lower limit bounds 
    /// If this is the case then reverse the direction from travelling up to travelling down and vice versa
    /// </summary>
    void Update()
    {
        if (movingDown == true && newPos.y < upperLimit)
        {
            movingDown = false;
            movingUp = true;
        }

        if (movingUp == true && newPos.y > lowerLimit)
        {
            movingUp = false;
            movingDown = true;
        }
    }

    /// <summary>
    /// Move the powerup up and down and rotate it so that it looks mystical and less static
    /// </summary>
    private void FixedUpdate()
    {
        if (movingDown)
        {
            newPos.y = newPos.y - 0.005f;
        }
        if (movingUp)
        {
            newPos.y = newPos.y + 0.005f;
        }

        powerUp.transform.position = newPos;
        powerUp.transform.Rotate(0.0f, 0.0f, 1.0f, Space.Self);
    }
}
