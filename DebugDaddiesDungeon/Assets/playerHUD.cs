using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHUD : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public Healthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int t_damage)
    {
        currentHealth -= t_damage;
        healthbar.setHealth(currentHealth);
    }
}
