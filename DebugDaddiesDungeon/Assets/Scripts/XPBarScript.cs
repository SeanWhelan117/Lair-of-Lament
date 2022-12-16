using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    /// <summary>
    /// Set the XPbar based on the current XP
    /// </summary>
    /// <param name="t_XP"></param>
    public void setXP(float t_XP)
    {
        slider.value = t_XP;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    /// <summary>
    /// Set the max XP of the XP bar with the players given max XP
    /// </summary>
    /// <param name="t_XP"></param>
    public void setMaxXP(float t_XP)
    {
        slider.maxValue = t_XP;
        slider.value = t_XP;

        fill.color = gradient.Evaluate(1f);
    }

    /// <summary>
    /// Change the max value of the slider for the XPBar UI
    /// </summary>
    /// <param name="value"></param>
    public void changeMaxValue(int value)
    {
        slider.maxValue += value;
    }

    /// <summary>
    /// Reset the max value of the XPBar UI
    /// </summary>
    public void resetMaxValue()
    {
        slider.maxValue = 100;
    }




}
