using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  int MaxHealth = 100;
    public float CurrentHealth;

    public HealthBar healthBar;
    public bool Dead = false;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    private void Update()
    {
        if (CurrentHealth <= 0 && !Dead)
        {
            die();
            Dead = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(2);
        }
    }

    void TakeDamage(int damage)
    {
        if (CurrentHealth <= 0)
        {
            Debug.LogError("You're already dead");
        }
        else
        {
            CurrentHealth -= damage;

            healthBar.SetHealth(CurrentHealth);
        }
    }

    void die()
    {
        if (!Dead)
        {
            Debug.Log("oh no you're dead");
        }
        
    }
}
