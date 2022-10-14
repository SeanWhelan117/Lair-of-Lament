using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void setHealth(int t_health)
    {
        slider.value = t_health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxHealth(int t_health)
    {
        slider.maxValue = t_health;
        slider.value = t_health;

       fill.color = gradient.Evaluate(1f);
    }
}
