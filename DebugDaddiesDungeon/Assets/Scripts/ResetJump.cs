using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetJump : MonoBehaviour
{
    public PlayerFifi player;

    /// <summary>
    /// Checks if the player has returned to the ground after jumping.
    /// If this has happened, set grounded to true, reset the jumpCount
    /// and also set the animation for player jumping to false
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.isGrounded = true;
            player.jumpCount = 0;
            player.animator.SetBool("isJumping", false);
        }
    }

}
