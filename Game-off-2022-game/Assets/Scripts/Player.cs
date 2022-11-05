using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public  int MaxHealth = 100;
    public float CurrentHealth;
    public int MaxShield = 20;
    public int Shield = 0;

    public HealthBar healthBar;
    public ShieldBar shieldBar;
    public bool Dead = false;

    private void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        shieldBar.SetMaxShield(MaxShield);
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GainShield(20);
        }
    }

    void GainShield(int ShieldGained)
    {
        Shield += ShieldGained;
        shieldBar.SetShield(Shield);
    }

    void LoseShield(int ShieldLost)
    {
        Shield -= ShieldLost;
        shieldBar.SetShield(Shield);
    }

    void TakeDamage(int damage)
    {
        if (Shield <= 0)
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
        else
        {
            LoseShield(damage);
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
