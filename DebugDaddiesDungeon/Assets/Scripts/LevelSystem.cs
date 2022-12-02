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
    void Start()
    {
        xpBar.setXP(currentXp / requiredXp);
    }

    // Update is called once per frame
    void Update()
    {
        xpBar.setXP(currentXp);
    }

    void GainExperienceFlatRate(float xpGained)
    {
        currentXp = xpGained;
    }
}
