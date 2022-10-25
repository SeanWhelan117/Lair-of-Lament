using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHUD : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    float currentStamina;
    float maxStamina = 100;

    public Healthbar healthbar;
    public StaminaBar staminaBar;

    public Slider staminaSlider;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);

        currentStamina = maxStamina;
        staminaBar.setMaxStamina(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("WAlking");
            if (currentStamina <= maxStamina)
            {
                currentStamina += 1.0f * Time.deltaTime;
                loseStamina(currentStamina);
                staminaBar.setStamina(currentStamina);
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (currentStamina > 0)
            {
                currentStamina -= 10.0f * Time.deltaTime;
                loseStamina(currentStamina);
            }
        }

        else
        {
            if (currentStamina <= 100)
            {
                currentStamina += 2.0f * Time.deltaTime;
            }
        }



    }

    public void TakeDamage(int t_damage)
    {
        currentHealth -= t_damage;
        healthbar.setHealth(currentHealth);
    }

    public void loseStamina(float t_stamina)
    {
        currentStamina -= t_stamina;
        staminaBar.setStamina(currentStamina);
    }

}
