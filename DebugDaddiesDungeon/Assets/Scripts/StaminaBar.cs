using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    /// <summary>
    /// set the stamina bars value and colour gradient based on the given stamina
    /// Called whenever the stamina is changed
    /// </summary>
    /// <param name="t_stamina"></param>
    public void setStamina(float t_stamina)
    {
        slider.value = t_stamina;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    /// <summary>
    /// Set the max value of the stamina with a given stamina parameter
    /// Set fill colour doing this too. Gradient 
    /// </summary>
    /// <param name="t_stamina"></param>
    public void setMaxStamina(float t_stamina)
    {
        slider.maxValue = t_stamina;
        slider.value = t_stamina;

        fill.color = gradient.Evaluate(1f);
    }
    
}
