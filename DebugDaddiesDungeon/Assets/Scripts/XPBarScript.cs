using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;


    public void setXP(float t_XP)
    {
        slider.value = t_XP;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxXP(float t_XP)
    {
        slider.maxValue = t_XP;
        slider.value = t_XP;

        fill.color = gradient.Evaluate(1f);
    }

    public void changeMaxValue(int value)
    {
        slider.maxValue += value;
    }

    public void resetMaxValue()
    {
        slider.maxValue = 100;
    }




}
