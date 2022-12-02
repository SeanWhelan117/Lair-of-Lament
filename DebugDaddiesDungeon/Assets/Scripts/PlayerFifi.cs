using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFifi : MonoBehaviour
{
    [Header("Health and stamina variables")]
    public int maxHealth = 5;
    public int currentHealth;
    public float stamina = 0;
    public float maxStamina = 100;
    public float staminaIncrease = 3;
    public float staminaDrain = 3;

    [Header("Healthbar and stamina bar")]
    public Healthbar healthbar;
    public StaminaBar staminaBarScript;
    public Slider staminaBar;

    [Header("Player stuff")]
    public Rigidbody2D rb;
    public float jumpForce = 0;
    public int jumpCount = 0;
    public int allowedJumps = 0;
    public float gravityScale = 0;
    public float fallingGravityScale = 0;
    public bool isGrounded = false;
    public float playerSpeed = 5.0f;
    public bool m_FacingRight = true;
    public bool m_FacingLeft = false;
    Vector2 savedlocalScale;
    public Animator animator;
    public bool resetJump = false;
  
    private float cooldownTimer = 5;

    public short damage = 10; // Base damage for the player

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);

        stamina = maxStamina;
        staminaBarScript.setMaxStamina(stamina);

        rb = GetComponent<Rigidbody2D>();
        savedlocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        ////////////////////////////////////////////////////////////////////////////            <<--------- MOVEMENT
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        if (rb.velocity.x > 0.001f)
        {
            animator.SetFloat("speed", Mathf.Abs(playerSpeed));
            transform.localScale = new Vector2(savedlocalScale.x, savedlocalScale.y);
            m_FacingLeft = false;
            m_FacingRight = true;
            if (stamina > 5)
            {
                DecreaseEnergy();
            }
        }
        else if (rb.velocity.x < -0.001f)
        {
            animator.SetFloat("speed", Mathf.Abs(playerSpeed));
            transform.localScale = new Vector2(-savedlocalScale.x, savedlocalScale.y);
            m_FacingLeft = true;
            m_FacingRight = false;
            if (stamina > 5)
            {
                DecreaseEnergy();
            }
        }

        if (rb.velocity.x == 0.0f)
        {
            animator.SetFloat("speed", Mathf.Abs(0));
            IncreaseEnergy();
        }

       if(stamina >= 10)
        {
            playerSpeed = 5.0f;
        }



        ////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////            <<--------- JUMPING


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            DecreaseEnergyJump();
            jumpCount += 1;
            if (jumpCount == allowedJumps)
            {
                isGrounded = false;
            }
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

        staminaBar.value = stamina;

        if (stamina <= 10.0f)
        {
            playerSpeed = 2.0f;
            IncreaseEnergy();
        }
        ////////////////////////////////////////////////////////////////////////////


        //currently reloading the main game scene again we can change this to do anything we need it to - Adam
        if (isPlayerDead() == true)
        {
            SceneManager.LoadScene("Level"); 
            Debug.Log("The Player Died - Do our restart scene ");
        }

        if (resetJump == true)
        {
            resetJumpingValues();
        }

       

    }

    public void TakeDamage(int t_damage)
    {
        currentHealth -= t_damage;
        healthbar.setHealth(currentHealth);

        if (isPlayerDead())
        {
            Destroy(this.gameObject);
        }
    }

    bool isPlayerDead() // checks if the player is dead
    {
        if (currentHealth <= 0)
            return true;
        else
            return false;
    }

    private void DecreaseEnergy()
    {
        if (stamina != 0.0f)
        {
            stamina -= staminaDrain * Time.deltaTime;
        }

        if (stamina <= 0)
        {
            stamina = 0.0f;
            playerSpeed = 2.0f;
        }

        staminaBarScript.setStamina(stamina);
    }

    private void DecreaseEnergyJump()
    {
        if (stamina != 0.0f)
        {
            stamina -= 4;
        }

        //check to make sure the stamina doesnt go past 0
        if (stamina <= 0)
        {
            stamina = 0.0f;
            playerSpeed = 2.0f;
        }
    }

    private void IncreaseEnergy()
    {
        stamina += staminaIncrease * Time.deltaTime;

        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }

        staminaBarScript.setStamina(stamina);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(1);
        }

    }

    //This function resets the values for jumping back to default after the 5 second timer.
    public void resetJumpingValues()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            jumpForce = 12;
            gravityScale = 8;
            resetJump = false;
        }

        Debug.Log(cooldownTimer);
        
    }

    //Function which resets the timer for the double jump pickups.
    public void resetTimer()
    {
        cooldownTimer = 5;
        resetJump = true;
    }

}
