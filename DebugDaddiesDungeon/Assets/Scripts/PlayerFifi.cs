using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using JetBrains.Annotations;
using Unity.VisualScripting;

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
    public float PLAYER_SPEED_DEFAULT = 5.0f;
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
    public short levelPoints = 0;
    public float currentXp;
    public float requiredXp;
    public Text levelText;

    public static PlayerFifi instance = null;

    /// <summary>
    /// On awake it checks if the player has an instance allready.
    /// if this is the case then the instance gameobject is removed.
    /// This ensures that the player is a singleton and just one exists at a time.
    /// </summary>
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Sets the variable neccessary for the player by calling the required functions.
    /// Xp bar 
    /// Health bar
    /// Stamina bar
    /// and the level text 
    /// are all set up by calling their various functions
    /// </summary>
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
    /// <summary>
    /// On update sets the animations of the player given the way the player is facing/ moving
    /// decresases the players stamina when movements are made
    /// Adds to the players stamina when they are percieved as standing still
    /// Set the players speed back to its default when their stamina is over or equal to 10
    /// Deals with the allowing the player to jump or not and then jumping the player
    /// sets the xpBar and stamina bar
    /// sets up a coroutine for if the player is killed.
    /// Runs said coroutine in the event of that happening
    /// Sets up leveling up for the player based on the XP that they have.
    /// Handles these levelups
    /// </summary>
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
            playerSpeed = PLAYER_SPEED_DEFAULT;
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
            playerSpeed = PLAYER_SPEED_DEFAULT / 2;
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
            levelPoints += 1;
            currentXp = 0;
            xpBarScript.setXP(currentXp);
            xpBarScript.setMaxXP(110);
            level = 2;
            levelText.text = "Level: " + level.ToString();
        }
        else if(level == 2 && currentXp >= 110)
        {
            levelPoints += 1;
            currentXp = 0;
            xpBarScript.setXP(currentXp);
            xpBarScript.setMaxXP(120);
            level = 3;
            levelText.text = "Level: " + level.ToString();
        }
        else if(level == 3 && currentXp >= 120)
        {
            levelPoints += 1;
            currentXp = 0;
            xpBarScript.setXP(currentXp);
            xpBarScript.setMaxXP(130);
            level = 4;
            levelText.text = "Level: " + level.ToString();
        }

        levelText.text = "Level: " + level.ToString();
        //Debug.Log(level);
    }

    /// <summary>
    /// takes in t_damage as a parameter and removes that from the players current health
    /// Sets the value of the healthbar UI based on the new health amount
    /// calls function which returns true if the player is killed
    /// </summary>
    /// <param name="t_damage"></param>
    public void TakeDamage(int t_damage)
    {
        currentHealth -= t_damage;
        healthbar.setHealth(currentHealth);

        if (isPlayerDead())
        {
            gameObject.transform.position = new Vector2(74, 60);
            
        }
    }

    /// <summary>
    /// Checks if the player is killed
    /// if health is less than or equal to 0 return true
    /// else return false
    /// </summary>
    /// <returns></returns>
    bool isPlayerDead() // checks if the player is dead
    {
        if (currentHealth <= 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Increase the max health of the player and set the players max health to this 
    /// this is one of the Upgrades with level up
    /// </summary>
    public void increasePlayerMaxHealth()
    {      
        maxHealth += 1;
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    /// <summary>
    /// Handles the decreasing of energy of the player
    /// This includes stamina drain over time and changing the player speed based on this
    /// the stamina bar is updated to reflect this change
    /// </summary>
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

    /// <summary>
    /// Decrease the energy/ stamina which the player has by a lot because they have done a jump
    /// Also changes player speed if the stamina is very low
    /// </summary>
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

    /// <summary>
    /// increase the energy of the player over time, up to the max energy / stamina possible
    /// the stamina bar script is used to reflect this
    /// This function is called when the player is standing still
    /// </summary>
    private void IncreaseEnergy()
    {
        stamina += staminaIncrease * Time.deltaTime;

        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
        }

        staminaBarScript.setStamina(stamina);
    }

    /// <summary>
    /// Checks collision with the projectile / NPC / XP / Spikes for the player and does accordingly
    /// For the NPC / Projectile / Spikes  the player calls the take damage function and passes an amount of damage
    /// For the XP the players current XP increases and the function for setting the XPbar to reflect this is called
    /// Once the player collides with the 'Health' pickup, health will be added and then the healthbar will be updated
    /// </summary>
    /// <param name="collision"></param>
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

        if(collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            currentHealth += 1;
            healthbar.setHealth(currentHealth);
        }

    }

    /// <summary>
    /// This function resets the values for jumping back to default after the 5 second timer.
    /// </summary>
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

    /// <summary>
    /// resets the timer for the double jump pickups.
    /// </summary>
    public void resetTimer()
    {
        cooldownTimer = 5;
        resetJump = true;
    }

}
