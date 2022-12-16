using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    /// <summary>
    /// takes in a t_health integer as a parameter.
    /// Sets player health using this.
    /// Additionally sets the fill color to a gradient slider which is noramlized
    /// This is for the gradient on the players health user interface
    /// </summary>
    /// <param name="t_health"></param>
    public void setHealth(int t_health)
    {
        slider.value = t_health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    /// <summary>
    /// Set the max health of the player
    /// This again uses an integer t_health as a parameter
    /// Sets the UI Sliders variables like maxValue etc using this function
    /// </summary>
    /// <param name="t_health"></param>
    public void setMaxHealth(int t_health)
    {
        slider.maxValue = t_health;
        slider.value = t_health;

       fill.color = gradient.Evaluate(1f);
    }
}
