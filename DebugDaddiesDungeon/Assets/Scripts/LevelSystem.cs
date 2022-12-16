using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    public int level;
    public float currentXp;
    public float requiredXp;

    [Header("UI")]
    public XPBarScript xpBar;


    // Start is called before the first frame update
    /// <summary>
    /// Sets the XP bars XP to the currentXp / requiredXp
    /// </summary>
    void Start()
    {
        xpBar.setXP(currentXp / requiredXp);
    }

    // Update is called once per frame
    /// <summary>
    /// sets the XP bar to the correct value / size for the current XP
    /// </summary>
    void Update()
    {
        xpBar.setXP(currentXp);
    }

    /// <summary>
    /// Add an amount of experience to the players current XP using a float paramerter called XPGained
    /// </summary>
    /// <param name="xpGained"></param>
    void GainExperienceFlatRate(float xpGained)
    {
        currentXp = xpGained;
    }
}
