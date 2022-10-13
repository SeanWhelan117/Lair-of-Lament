using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    public GameObject entity;

    private short health;

    private void Start()
    {
        health = entity.GetComponent<PlayerScriptSasa>().health;
    }

    public void entityTakesDamage(short t_health, short t_damage)
    {
        t_health -= t_damage;
        if (isEntityDead())
        {
            Destroy(entity);
        }

        entity.GetComponent<PlayerScriptSasa>().health = t_health;
        health = t_health;
    }

    bool isEntityDead()
    {
        if (health <= 0)
            return true;
        else
            return false;
    }
}
