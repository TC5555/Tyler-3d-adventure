using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    private int maxHealth;
    public void Start()
    {
        maxHealth = health;
    }
    public void ChangeHealth(int change)
    {
        Debug.Log(health);
        health += change;
        if(health < 0)
        {
            gameObject.SetActive(false);
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
