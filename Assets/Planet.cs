using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    float maxHealth = 100;
    float health;
    HealthBar myHealthBar;

    void Start()
    {
        myHealthBar = GetComponentInChildren<HealthBar>();
        health = maxHealth; 
        myHealthBar.SetHealthBar(1); //sets the healthbar to max value since starting at max health.
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            TakeDamage(10);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(-100);
        }
    }

    public void TakeDamage(float damage)
    {
        health = health-damage; //can also be written as health -= damage;
        float healthPercent = health/maxHealth; 
        myHealthBar.SetHealthBar(healthPercent);
    }

}
