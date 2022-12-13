using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerFifi : MonoBehaviour
{
    [Header("Health and stamina variables")]
    public int maxHealth = 5;
    public int currentHealth;
    public float stamina = 100;
    public float maxStamina = 100;
    public float staminaIncrease = 3;
    public float staminaDrain = 3;

    [Header("HUD Icon bars")]
    public Healthbar healthbar;
    public StaminaBar staminaBarScript;
    public Slider staminaBar;
    public XPBarScript xpBarScript;
    public Slider xpBarSlider;

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

    public bool torchInHand = true;

    [SerializeField] private float cooldown = 5;

    private float cooldownTimer = 5;
    public short damage = 10; // Base damage for the player

    [Header("XP Related variables")]
    public int level = 1;
    public float currentXp;
    public float requiredXp;
    public Text levelText;

    void Start()
    {
        level = 1;
        currentXp = 0;
        xpBarScript.setXP(currentXp);

        requiredXp = 100;

        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);

        stamina = maxStamina;
        staminaBarScript.setMaxStamina(stamina);

        rb = GetComponent<Rigidbody2D>();
        savedlocalScale = transform.localScale;

        levelText.text = "Level: " + level.ToString();

        
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
        xpBarSlider.value = currentXp;
        xpBarScript.setXP(currentXp);
        

        if (stamina <= 10.0f)
        {
            playerSpeed = 2.0f;
            IncreaseEnergy();
        }
        ////////////////////////////////////////////////////////////////////////////


        //currently reloading the main game scene again we can change this to do anything we need it to - Adam
        if (isPlayerDead() == true)
        {
            StartCoroutine(Killcam());
        }

        if (resetJump == true)
        {
            resetJumpingValues();
        }

        IEnumerator Killcam()
        {

            yield return new WaitForSeconds(6.0f);
            Debug.Log("The Player Died - Do our restart scene ");
            SceneManager.LoadScene("Level");
        }

        ////////////////////////////////////////////////////////////////////////////
        ///                     LEVEL UPS
        ////////////////////////////////////////////////////////////////////////////
        if (level == 1 && currentXp >= 100)
        {
            currentXp = 0;
            xpBarScript.setXP(currentXp);
            xpBarScript.setMaxXP(110);
            level = 2;
            levelText.text = "Level: " + level.ToString();
        }
        else if(level == 2 && currentXp >= 110)
        {
            currentXp = 0;
            xpBarScript.setXP(currentXp);
            xpBarScript.setMaxXP(120);
            level = 3;
            levelText.text = "Level: " + level.ToString();
        }
        else if(level == 3 && currentXp >= 120)
        {
            currentXp = 0;
            xpBarScript.setXP(currentXp);
            xpBarScript.setMaxXP(130);
            level = 4;
            levelText.text = "Level: " + level.ToString();
        }

        levelText.text = "Level: " + level.ToString();
        Debug.Log(level);
    }

    public void TakeDamage(int t_damage)
    {
        currentHealth -= t_damage;
        healthbar.setHealth(currentHealth);

        if (isPlayerDead())
        {
            gameObject.transform.position = new Vector2(74, 60);
            
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

        if(collision.gameObject.CompareTag("NPC"))
        {
            TakeDamage(1);
        }

        if(collision.gameObject.CompareTag("XP"))
        {
            Debug.Log("Collided with the xp drop");
            Destroy(collision.gameObject);
            currentXp += 25;//Random.Range(5, 10);
            xpBarScript.setXP(currentXp);

        }

        if (collision.gameObject.tag == "Spikes")
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
