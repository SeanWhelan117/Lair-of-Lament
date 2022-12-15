using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setStamina(float t_stamina)
    {
        slider.value = t_stamina;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxStamina(float t_stamina)
    {
        slider.maxValue = t_stamina;
        slider.value = t_stamina;

        fill.color = gradient.Evaluate(1f);
    }
    
}
