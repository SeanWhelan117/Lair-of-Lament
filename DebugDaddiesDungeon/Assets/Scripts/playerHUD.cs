using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHUD : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public Healthbar healthbar;
    public Slider staminaBar;

    public float stamina = 0;
    public float maxStamina = 100;
    public float staminaIncrease = 3;
    public float staminaDrain = 3;

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
    //public Animator animator;

    
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);

        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;

        rb = GetComponent<Rigidbody2D>();
        savedlocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1);
        }




        ////////////////////////////////////////////////////////////////////////////            <<--------- MOVEMENT
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        if (rb.velocity.x > 0.001f)
        {
            //animator.SetFloat("speed", Mathf.Abs(playerSpeed));
            transform.localScale = new Vector2(savedlocalScale.x, savedlocalScale.y);
            m_FacingLeft = false;
            m_FacingRight = true;
            DecreaseEnergy();
        }
        else if (rb.velocity.x < -0.001f)
        {
            //animator.SetFloat("speed", Mathf.Abs(playerSpeed));
            transform.localScale = new Vector2(-savedlocalScale.x, savedlocalScale.y);
            m_FacingLeft = true;
            m_FacingRight = false;
            DecreaseEnergy();
        }

        if (rb.velocity.x == 0.0f)
        {
            //animator.SetFloat("speed", Mathf.Abs(0));
            IncreaseEnergy();
        }

        ////////////////////////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////////////////////////            <<--------- JUMPING
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            //animator.SetBool("isJumping", true);
            jumpCount += 1;
            DecreaseEnergy();
            if (jumpCount == allowedJumps)
            {
                isGrounded = false;
            }
        }

        staminaBar.value = stamina;
        //if(stamina)

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
        ////////////////////////////////////////////////////////////////////////////

    }

    public void TakeDamage(int t_damage)
    {
        currentHealth -= t_damage;
        healthbar.setHealth(currentHealth);
    }

    private void DecreaseEnergy()
    {
        if(stamina != 0.0f)
        {
            stamina -= staminaDrain * Time.deltaTime;
        }
    }

    private void IncreaseEnergy()
    {
        stamina += staminaIncrease * Time.deltaTime;
    }


}
